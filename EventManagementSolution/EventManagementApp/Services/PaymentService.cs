using System.Text;
using System.Text.Json;
using EventManagementApp.Context;
using EventManagementApp.DTOs.Payment;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EventManagementApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IScheduledEventRepository _scheduledEventRepository;
        private readonly EventManagementDBContext _context;

        private string PAYMENT_API_KEY { get; }
        private string PAYMENT_URL { get; }
        private string WEBHOOK_SECRET_KEY { get; }

        public PaymentService(IOrderRepository orderRepository,
            IConfiguration configuration,
            ITransactionRepository transactionRepository,
            IScheduledEventRepository scheduledEventRepository,
            EventManagementDBContext context)
        {
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
            _scheduledEventRepository = scheduledEventRepository;
            _context = context;

            var api_key = configuration.GetSection("PaymentCredentials").GetSection("API_KEY").Value;
            PAYMENT_API_KEY = api_key != null ? api_key.ToString() : throw new NullReferenceException("Cannot get Payment API_KEY from Configuration file");

            var value = configuration.GetSection("PaymentCredentials").GetSection("PaymentURL").Value;
            PAYMENT_URL = value != null ? value.ToString() : throw new NullReferenceException("Cannot get Payment URL from Configuration file");

            var WebHookSecretKey = configuration.GetSection("WebhookCredentials").GetSection("KEY").Value;
            WEBHOOK_SECRET_KEY = WebHookSecretKey != null ? WebHookSecretKey.ToString() : throw new NullReferenceException("Cannot get Payment URL from Configuration file");

        }


        public async Task<MakePaymentReturnDTO> MakePayment(int userId, int orderId)
        {

            Order userOrder = await _orderRepository.GetUserOrderById(userId, orderId);

            if (userOrder == null)
            {
                throw new NoOrderFoundException();
            }

            if (userOrder.OrderStatus == OrderStatus.Completed)
            {
                throw new PaymentAlreadyCompletedException();
            }

            var paymentData = new
            {
                Amount = userOrder.TotalAmount,
                Currency = "INR"
            };

            var jsonPayload = JsonSerializer.Serialize(paymentData);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("API_KEY", PAYMENT_API_KEY);

            var response = await httpClient.PostAsync(PAYMENT_URL, content);

            if (response.StatusCode.ToString() == "Unauthorized")
            {
                throw new PaymentGatewayUnauthorizedException();
            }

            response.EnsureSuccessStatusCode(); // Throws error if there is not a successful response


            string responseContent = await response.Content.ReadAsStringAsync();
            PaymentResponseDTO? paymentResult = JsonSerializer.Deserialize<PaymentResponseDTO>(responseContent);
            if (paymentResult == null)
            {
                throw new NullReferenceException("Payment response is not deserializable");
            }

            Transaction transaction = new Transaction
            {
                Amount = userOrder.TotalAmount,
                PaymentURL = paymentResult.PaymentURL,
                TransactionId = paymentResult.TransactionId
            };


            userOrder.Transactions = new List<Transaction> { transaction };
            await _orderRepository.Update(userOrder);

            return new MakePaymentReturnDTO
            {
                PaymentURL = paymentResult.PaymentURL,
                TransactionId = paymentResult.TransactionId
            };
        }

        public async Task UpdateTransactionDetails(PaymentNotificationDTO paymentNotificationDTO, IHeaderDictionary headers)
        {
            string? KeyFromPaymentGateway = headers["SECRET_KEY"];

            if (KeyFromPaymentGateway != WEBHOOK_SECRET_KEY)
            {
                throw new UnauthorizedAccessException("Webhook Request Key is Invalid");
            }

            Transaction transaction = await _transactionRepository.GetByIdWithOrder(paymentNotificationDTO.TransactionId);

            if (transaction == null)
            {
                throw new NoTransactionFoundException();
            }

            using (var DBTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    transaction.PaymentStatus = paymentNotificationDTO.PaymentStatus;
                    transaction.PaymentMethod = paymentNotificationDTO.PaymentMethod;

                    if (transaction.PaymentStatus == PaymentStatus.Completed)
                    {
                        transaction.Order.OrderStatus = OrderStatus.Completed;
                        ScheduledEvent scheduledEvent = new ScheduledEvent
                        {
                            UserId = transaction.Order.UserId,
                            ClienResponseId = transaction.Order.ClientResponseId,
                            EventCategoryId = transaction.Order.EventCategoryId,
                            QuotationRequestId = transaction.Order.ClientResponse.QuotationResponse.QuotationRequestId
                        };

                        await _scheduledEventRepository.Add(scheduledEvent);
                    }

                    await _transactionRepository.Update(transaction);
                    await DBTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await DBTransaction.RollbackAsync();
                    throw ex;
                }
            }
        }

    }
}
