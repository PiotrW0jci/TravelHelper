using System.Threading.Tasks;
using TravelHelper.Core.Domain;

namespace TravelHelper.Infrastructure.Repositories
{
    public interface IAuthRepository
    {
         Task<User> Login(string username, string password);
         Task<User> Register(User user, string password);
         Task <bool> UserExist(string username);
    }
}