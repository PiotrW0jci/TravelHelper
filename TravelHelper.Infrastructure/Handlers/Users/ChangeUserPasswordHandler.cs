using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler <ChangeUserPassword>
    {
        private readonly IUserService _userService;
         public ChangeUserPasswordHandler(IUserService userService)
        {
        _userService = userService;   
        }
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await _userService.ChangeUserPasswordAsync(command.UserId,command.CurrentPassword,command.NewPassword);
        }
    }
}