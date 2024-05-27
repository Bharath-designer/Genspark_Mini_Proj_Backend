using EventManagementApp.Context;
using EventManagementApp.Interfaces;
using EventManagementApp.Models;

namespace EventManagementApp.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(EventManagementDBContext _context) : base(_context)
        {
        }
    }
}
