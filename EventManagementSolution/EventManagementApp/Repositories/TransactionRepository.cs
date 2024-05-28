using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class TransactionRepository : Repository<Transaction, string>, ITransactionRepository
    {
        public TransactionRepository(EventManagementDBContext _context) : base(_context)
        {
        }

        public async Task<Transaction> GetByIdWithOrder(string id)
        {
            Transaction? transaction = await _context.Transactions
                .Include(t => t.Order)
                .ThenInclude(o=>o.ClientResponse)
                .ThenInclude(c=>c.QuotationResponse)
                .FirstOrDefaultAsync(t=>t.TransactionId == id);
            return transaction;
        }
    }
}
