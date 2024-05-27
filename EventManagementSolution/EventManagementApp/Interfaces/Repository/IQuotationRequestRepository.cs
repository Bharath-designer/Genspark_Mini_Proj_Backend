using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface IQuotationRequestRepository: IRepository<QuotationRequest, int>
    {
        public Task<QuotationRequest> GetById(int id, int userId);

    }
}
