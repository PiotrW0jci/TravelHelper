using System.Reflection.Metadata;
using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelHelper.Infrastructure.Services;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Commands;
using Microsoft.Extensions.Caching.Memory;
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
         var user= _context.Users.FirstOrDefault(x => x.Email == email);
            if(user==null)
             {
                 return NotFound();
             }
             return Json(user);

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return StatusCode(201);
        }
        
        [HttpGet("activate/{token}")]
        public async Task<IActionResult>  Post(ActivateUser command)
        {
             await CommandDispatcher.DispatchAsync(command);
           
            return StatusCode(201);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
            {
                await CommandDispatcher.DispatchAsync(command);
                return Created($"user/{command.Email}",new object());
            }
        
        
       [HttpPost("login")]
       public async Task<IActionResult> Post([FromBody]Login command)
            {         
                 await CommandDispatcher.DispatchAsync(command);
                 var user= _context.Users.FirstOrDefault(x => x.Email == command.Email);
                 return Json(user);
            }

         [HttpPost("changePassword")]
       public async Task<IActionResult> Change([FromBody]ChangeUserPassword command)
            {         
                 await CommandDispatcher.DispatchAsync(command);
                
                 return StatusCode(201);
            }
    
          
          
       
        
        
    }

}
