using System.Threading.Tasks;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public interface IUserService : IService
    {
        //Task <UserDto> GetAsync(string email);
        Task<User> RegisterAsync(string email,string username,string password);
        Task<User> LoginAsync(string email,string password);
         
        // Task<User> Login(string username, string password);
         //Task<User> Register(User user, string password);
        
    }
}