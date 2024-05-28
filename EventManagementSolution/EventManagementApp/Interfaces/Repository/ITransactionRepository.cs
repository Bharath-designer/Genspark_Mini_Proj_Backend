
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface ITransactionRepository: IRepository<Transaction, string>
    {
        public Task<Transaction> GetByIdWithOrder(string id);
    }
}
