using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces
{
    public interface IOrderRepository: IRepository<Order, int>
    {
        public Task<Order> GetUserOrderById(int userId, int orderId);
    }
}
