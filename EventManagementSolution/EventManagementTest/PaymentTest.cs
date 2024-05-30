using EventManagementApp.DTOs.Payment;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EventManagementTest
{
    class PaymentTest
    {
        private TestDBContext _context;
        private IPaymentService _paymentService;
        private IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {
            _context = new TestDBContext(TestDBContext.GetInMemoryOptions());

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            IOrderRepository orderRepo = new OrderRepository(_context);
            IConfiguration configuration = new InMemoryConfiguration().Configuration;
            _configuration = configuration;
            ITransactionRepository transactionRepo = new TransactionRepository(_context);
            IScheduledEventRepository scheduledEventRepository = new ScheduledEventRepository(_context);
            _paymentService = new PaymentService(orderRepo, configuration,transactionRepo,scheduledEventRepository, _context );
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task MakePayment()
        {
            var returnDTO = await _paymentService.MakePayment(2, 3);

            Assert.IsNotNull(returnDTO);
        }


        [Test]
        public async Task MakePaymentFail1()
        {

            Assert.ThrowsAsync<NoOrderFoundException>(async () => { 
                var returnDTO = await _paymentService.MakePayment(2, 999);
            });

        }

        [Test]
        public async Task PaymentNotification()
        {
            PaymentNotificationDTO paymentNotificationDTO = new PaymentNotificationDTO
            {
                TransactionId = "1d431806-1830-41d7-befa-e2a9d7053896",
                PaymentMethod = "Card",
                PaymentStatus = PaymentStatus.Completed
            };

            IHeaderDictionary headers = new HeaderDictionary();
            headers["SECRET_KEY"] = "8a3a6e0967f0184db8a317910239ac2521a329783e2d88a1edeb3e";

            await _paymentService.UpdateTransactionDetails(paymentNotificationDTO, headers);
        }

        [Test]
        public async Task PaymentNotificationFailTest1()
        {
            PaymentNotificationDTO paymentNotificationDTO = new PaymentNotificationDTO
            {
                TransactionId = "1",
                PaymentMethod = "Card",
                PaymentStatus = PaymentStatus.Completed
            };

            IHeaderDictionary headers = new HeaderDictionary();
            headers["SECRET_KEY"] = "8a3a6e0967f0184db8a317910239ac2521a329783e2d88a1edeb3e";


            Assert.ThrowsAsync<NoTransactionFoundException>(async () => {
            await _paymentService.UpdateTransactionDetails(paymentNotificationDTO, headers);
            });

        }

        [Test]
        public async Task PaymentNotificationFailTest2()
        {
            PaymentNotificationDTO paymentNotificationDTO = new PaymentNotificationDTO
            {
                TransactionId = "1d431806-1830-41d7-befa-e2a9d7053896",
                PaymentMethod = "Card",
                PaymentStatus = PaymentStatus.Completed
            };

            IHeaderDictionary headers = new HeaderDictionary();
            headers["SECRET_KEY"] = "1234";


            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => {
                await _paymentService.UpdateTransactionDetails(paymentNotificationDTO, headers);
            });

        }


    }
}
