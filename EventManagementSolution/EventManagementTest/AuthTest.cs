using EventManagementApp.DTOs.User;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;
using EventManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventManagementTest
{
    public class AuthTest
    {
        private TestDBContext _context;
        private AuthService _authService;

        [SetUp]
        public void Setup()
        {
            _context = new TestDBContext(TestDBContext.GetInMemoryOptions());

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();


            IConfiguration configuration = new InMemoryConfiguration().Configuration;

            IUserRepository _userRepo = new UserRespository(_context);
            ITokenService _tokenService = new TokenService(configuration);
            _authService = new AuthService(_userRepo, _tokenService);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateUserSuccessAsync()
        {
            // Arrange
            RegisterDTO registerDTO = new RegisterDTO
            {
                Email = "user2@gmail.com",
                FullName = "Test",
                PhoneNumber = "98439823434",
                Password = "strongpassword"
            };

            // Act
            await _authService.AddUser(registerDTO);

            // Assert
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);
            Assert.IsNotNull(user);

        }

        [Test]
        public async Task CreateUserFailAsync()
        {
            // Arrange
            RegisterDTO registerDTO = new RegisterDTO
            {
                Email = "test2@gmail.com",
                FullName = "Test",
                PhoneNumber = "98439823434",
                Password = "strongpassword"
            };

            // Act
            await _authService.AddUser(registerDTO);

            // Assert
            Assert.ThrowsAsync<EmailAlreadyExistsException>(async () =>
            {
                await _authService.AddUser(registerDTO);
            });
        }

        [Test]
        public async Task LoginSuccessTest()
        {
            //Arrange
            // Arrange
            RegisterDTO registerDTO = new RegisterDTO
            {
                Email = "testloginsuccess@gmail.com",
                FullName = "Test",
                PhoneNumber = "98439823434",
                Password = "strongpassword"
            };

            // Act

            var LoginDTO = new LoginDTO
            {
                Email = "testloginsuccess@gmail.com",
                Password = "strongpassword"
            };

            // Act
            await _authService.AddUser(registerDTO);
            var loginReturnDTO = await _authService.Login(LoginDTO);

            // Assert
            Assert.IsNotNull(loginReturnDTO);

        }

        [Test]
        public async Task LoginFailTest1()
        {
            //Arrange

            var LoginDTO = new LoginDTO
            {
                Email = "unknown@gmail.com",
                Password = "strongpassword"
            };

            // Assert
            Assert.ThrowsAsync<InvalidEmailOrPasswordException>(async() => { 
                var loginReturnDTO = await _authService.Login(LoginDTO);
            });
        }
    }
}
