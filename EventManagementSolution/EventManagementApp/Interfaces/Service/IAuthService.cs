using EventManagementApp.DTOs.User;

namespace EventManagementApp.Interfaces.Service
{
    public interface IAuthService
    {
        /// <exception cref="EmailAlreadyExistsException"></exception>
        public Task AddUser(RegisterDTO registerDTO);

        /// <exception cref="InvalidEmailOrPasswordException"></exception>
        public Task<LoginReturnDTO> Login(LoginDTO loginDTO);
    }
}
