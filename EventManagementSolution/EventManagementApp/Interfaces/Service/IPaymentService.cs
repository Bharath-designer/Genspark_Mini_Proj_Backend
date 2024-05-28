using EventManagementApp.DTOs.Payment;
using EventManagementApp.Exceptions;

namespace EventManagementApp.Interfaces.Service
{
    public interface IPaymentService
    {
        /// <exception cref="NoOrderFoundException"></exception>
        /// <exception cref="PaymentGatewayUnauthorizedException"></exception>
        /// <exception cref="PaymentAlreadyCompletedException"></exception>
        public Task<MakePaymentReturnDTO> MakePayment(int userId, int orderId);

        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="NoTransactionFoundException"></exception>
        public Task UpdateTransactionDetails(PaymentNotificationDTO paymentNotificationDTO, IHeaderDictionary headers);

    }
}
