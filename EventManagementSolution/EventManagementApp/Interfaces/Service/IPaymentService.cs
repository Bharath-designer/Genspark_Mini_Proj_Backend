namespace EventManagementApp.Interfaces.Service
{
    public interface IPaymentService
    {
        public Task MakePayment(int userId, int orderId);
    }
}
