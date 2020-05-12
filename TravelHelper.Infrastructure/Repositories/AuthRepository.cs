using System.Threading.Tasks;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.Data;

namespace TravelHelper.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
           
        }

        public Task<bool> UserExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}