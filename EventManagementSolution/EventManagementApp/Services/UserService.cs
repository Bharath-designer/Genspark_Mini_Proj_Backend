using System.Security.Cryptography;
using System.Text;
using EventManagementApp.DTOs;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;

namespace EventManagementApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        public async Task AddUser(RegisterDTO registerDTO)
        {
            User existingUser = await _userRepository.GetUserByEmail(registerDTO.Email);
            if (existingUser != null) {
                throw new EmailAlreadyExistsException();
            }

            User user = MapRegisterDTOWithUser(registerDTO);
            await _userRepository.Add(user);

        }

        private User MapRegisterDTOWithUser(RegisterDTO registerDTO)
        {
            User user = new User();
            user.Email = registerDTO.Email;
            user.FullName = registerDTO.FullName;
            user.PhoneNumber = registerDTO.PhoneNumber;
            user.UserCredential = CreateUserCredential(registerDTO.Password);
            return user;
        }

        private UserCredential CreateUserCredential(string plainPassword)
        {
            UserCredential credential = new UserCredential();
            HMACSHA512 hMACSHA = new HMACSHA512();

            credential.HaskKey = hMACSHA.Key;
            credential.HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            credential.Role = UserType.Admin;

            return credential;
        }
    }
}
