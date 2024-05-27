using EventManagementApp.DTOs.QuotationRequest;

namespace EventManagementApp.Interfaces.Service
{
    public interface IQuotationRequestService
    {
        public Task CreateQuotationRequest(int UserId, CreateQuotationRequestDTO quotationRequestDTO);
    }
}
