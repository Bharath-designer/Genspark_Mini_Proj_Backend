using EventManagementApp.Interfaces;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;

namespace EventManagementApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _orderRepository;

        public PaymentService(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }

        public Task MakePayment(int userId, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
