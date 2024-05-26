using EventManagementApp.DTOs;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Service
{
    public interface IUserService
    {
        /// <exception cref="EmailAlreadyExistsException"></exception>
        public Task AddUser(RegisterDTO registerDTO);
    }
}
