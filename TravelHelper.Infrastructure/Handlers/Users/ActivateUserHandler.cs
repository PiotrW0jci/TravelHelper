using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Services;
using TravelHelper.Infrastructure.Extensions;

namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class ActivateUserHandler : ICommandHandler<ActivateUser>
    {
       private readonly IUserService _userService;
     
       
        public ActivateUserHandler(IUserService userService)
        {
        _userService = userService;   
        }
        public async Task HandleAsync(ActivateUser command)
        {

            await _userService.ActivateUserAsync(command.Token);
        }


    }
}