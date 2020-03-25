using System.Threading.Tasks;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Services;

namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
       
        public CreateUserHandler(IUserService userService)
        {
        _userService = userService;   
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email,command.Username,command.Password);
        }
    }
}