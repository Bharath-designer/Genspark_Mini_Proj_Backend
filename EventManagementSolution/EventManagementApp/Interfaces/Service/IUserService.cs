using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.DTOs.User;
using EventManagementApp.Exceptions;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Service
{
    public interface IUserService
    {
        public Task<List<UserRequestListDTO>> GetUserRequests(int userId);
        public Task<UserQuotationRequestDTO> GetUserRequestById(int userId, int quotationRequestId);
        public Task<List<UserOrderListReturnDTO>> GetUserOrders(int userId);

    }
}
