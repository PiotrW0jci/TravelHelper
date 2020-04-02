using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Services;
using TravelHelper.Infrastructure.Extensions;

namespace TravelHelper.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
       private readonly IUserService _userService;
       private readonly IJwtHandler _jwtHandler;
       private readonly IMemoryCache _cache;

       public LoginHandler(IUserService userService,IJwtHandler jwtHandler,
            IMemoryCache cache)
       {
           _userService= userService;
           _jwtHandler= jwtHandler;
           _cache = cache; 
           
       }
        public async Task HandleAsync(Login command)
        {
           // throw new System.NotImplementedException();
            var jwt =_jwtHandler.CreateToken(command.Email);
            _cache.SetJwt(command.TokenId,jwt);
            await _userService.LoginAsync(command.Email,command.Password);
                    }
        
    }
}