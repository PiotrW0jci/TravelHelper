using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelHelper.Infrastructure.DTO;
using TravelHelper.Infrastructure.Services;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Commands;
using Microsoft.Extensions.Caching.Memory;
using TravelHelper.Infrastructure.Extensions;
using TravelHelper.Infrastructure.Data;

namespace TravelHelper.Api.Controllers
{
     

    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        public UsersController(IUserService userService, 
        ICommandDispatcher commandDispatcher,IJwtHandler jwtHandler,IMemoryCache cache, DataContext context) : base(commandDispatcher)
        {
        _cache =cache;
        _userService = userService;
        _jwtHandler = jwtHandler;  
        _context= context;
        }
        
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
         //var user=await _userService.GetAsync(email);
         var user= _context.Users.FirstOrDefault(x => x.Email ==email);
            if(user==null)
             {
                 return NotFound();
             }
             return Json(user);

        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
            {
                await CommandDispatcher.DispatchAsync(command);
                return Created($"user/{command.Email}",new object());
            }
        
        
      //  [HttpPost("login")]
      //  public async Task<IActionResult> Post([FromBody]LoginAsync command)
      //  {//            await CommandDispatcher.DispatchAsync(command);
    //        return 
     //   }
    //       
          
         [HttpGet]
         [Route("token")]
         public async Task<IActionResult> GetToken()
            {
                var token = _jwtHandler.CreateToken("user1@email.com");
                return Json(token);
            }
         [HttpGet]
         [Route("auth")]
         public async Task<IActionResult> GetAuth()
            {
                return Json("Auth");
            }
        
        
    }

}
