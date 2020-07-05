using System.Threading.Tasks;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public interface IUserService : IService
    {
    
        Task<User> RegisterAsync(string email,string username,string password);
        Task<User> LoginAsync(string email,string password);
        Task<User> ActivateUserAsync(string token);
        Task<User> ChangeUserPasswordAsync(string id, string password,string newPassword);

    }
}