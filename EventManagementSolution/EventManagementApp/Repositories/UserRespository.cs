using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class UserRespository : Repository<User, int>, IUserRepository
    {
        public UserRespository(EventManagementDBContext context) : base(context) {}

        public async Task<User> GetUserByEmail(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
            return user;
        }

        public async Task<User> GetUserByEmailWithUserCredential(string email)
        {
            User? user = await _context.Users.Include(u => u.UserCredential).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}