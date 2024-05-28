using EventManagementApp.Context;
using EventManagementApp.Interfaces;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(EventManagementDBContext _context) : base(_context)
        {
        }

        public async Task<Order> GetUserOrderById(int userId, int orderId)
        {
            Order? order = await _context.Orders.FirstOrDefaultAsync(o=> o.UserId == userId && o.OrderId == orderId);
            return order;
        }
    }
}
