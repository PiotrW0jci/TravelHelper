using System.Threading.Tasks;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task <UserDto> GetAsync(string email);
         Task RegisterAsync(string email,string username,string password);
         Task LoginAsync(string email,string password);
    }
}