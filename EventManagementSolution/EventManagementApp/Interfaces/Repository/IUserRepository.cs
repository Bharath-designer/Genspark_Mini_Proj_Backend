using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.DTOs.User;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User, int>
    {
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByEmailWithUserCredential(string email);
        public Task<List<UserRequestListDTO>> GetUserRequests(int userId);
        public Task<UserQuotationRequestDTO> GetUserRequestById(int userId, int quotationRequestId);
        public Task<List<UserOrderListReturnDTO>> GetUserOrders(int userId);


    }
}
