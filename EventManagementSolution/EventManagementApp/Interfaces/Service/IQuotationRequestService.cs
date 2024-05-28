using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Exceptions;
namespace EventManagementApp.Interfaces.Service
{
    public interface IQuotationRequestService
    {
        /// <exception cref="NoEventCategoryFoundException" />
        public Task CreateQuotationRequest(int UserId, CreateQuotationRequestDTO quotationRequestDTO);
    }
}
