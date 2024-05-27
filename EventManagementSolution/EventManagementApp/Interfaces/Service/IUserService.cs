using EventManagementApp.DTOs.User;
using EventManagementApp.Exceptions;

namespace EventManagementApp.Interfaces.Service
{
    public interface IUserService
    {
        /// <exception cref="InvalidEmailOrPasswordException"></exception>
        public Task AddUser(RegisterDTO registerDTO);

        /// <exception cref="InvalidEmailOrPasswordException"></exception>
        public Task<LoginReturnDTO> Login(LoginDTO loginDTO);
    }
}
