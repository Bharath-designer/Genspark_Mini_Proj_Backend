using System.Security.Cryptography;
using System.Text;
using EventManagementApp.DTOs.User;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;

namespace EventManagementApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService) { 
            _userRepository = userRepository;
            _tokenService = tokenService;
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

            credential.HashKey = hMACSHA.Key;
            credential.HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            credential.Role = UserType.User;

            return credential;
        }

        public async Task<LoginReturnDTO> Login(LoginDTO loginDTO)
        {
            User storedUser = await _userRepository.GetUserByEmailWithUserCredential(loginDTO.Email);
            if (storedUser == null)
            {
                throw new InvalidEmailOrPasswordException();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(storedUser.UserCredential.HashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            bool isPasswordSame = ComparePassword(encrypterPass, storedUser.UserCredential.HashedPassword);
            if (isPasswordSame)
            {
                LoginReturnDTO loginReturnDTO = new LoginReturnDTO();
                loginReturnDTO.UserId = storedUser.UserId;
                loginReturnDTO.token = _tokenService.GenerateToken(storedUser);
                return loginReturnDTO;
            }
            throw new InvalidEmailOrPasswordException();
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
