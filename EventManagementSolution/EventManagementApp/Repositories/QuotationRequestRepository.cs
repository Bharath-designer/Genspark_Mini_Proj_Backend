using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class QuotationRequestRepository : Repository<QuotationRequest, int>, IQuotationRequestRepository
    {
        public QuotationRequestRepository(EventManagementDBContext _context) : base(_context)
        {
        }

        public async Task<QuotationRequest> GetById(int id, int userId)
        {
            return await _context.QuotationRequests.FirstOrDefaultAsync(q=>q.QuotationRequestId == id && q.UserId == userId);
        }

        
    }
}
