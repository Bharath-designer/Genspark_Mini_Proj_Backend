using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User, int>
    {
        public Task<User> GetUserByEmail(string email);
    }
}
