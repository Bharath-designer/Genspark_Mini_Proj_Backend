using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;

namespace EventManagementApp.Repositories
{
    public class ClientResponseRepository : Repository<ClientResponse, int>, IClientResponseRepository
    {
        public ClientResponseRepository(EventManagementDBContext _context) : base(_context)
        {
        }
    }
}
