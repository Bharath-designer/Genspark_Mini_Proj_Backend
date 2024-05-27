using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.DTOs.User;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;

namespace EventManagementApp.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserQuotationRequestDTO> GetUserRequestById(int userId, int quotationRequestId)
        {
            UserQuotationRequestDTO quotationRequest = await _userRepository.GetUserRequestById(userId, quotationRequestId);
            return quotationRequest;
        }

        public async Task<List<UserRequestListDTO>> GetUserRequests(int userId)
        {
            List<UserRequestListDTO> quotationRequests = await _userRepository.GetUserRequests(userId);
            return quotationRequests;

        }

        public async Task<List<UserOrderListReturnDTO>> GetUserOrders(int userId)
        {
            return await _userRepository.GetUserOrders(userId);
        }

    }
}
