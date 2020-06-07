using System.Data;
using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TravelHelper.Infrastructure.Commands;
using TravelHelper.Infrastructure.Commands.Users;
using TravelHelper.Infrastructure.Data;
using TravelHelper.Infrastructure.Extensions;
using System.IdentityModel.Tokens ;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TravelHelper.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache, DataContext context,IConfiguration config) :base(commandDispatcher)
        {
            _cache = cache;
            _context= context;
            _config = config;
        }
    
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }   
        [HttpPost("login")]
       public async Task<IActionResult> Login([FromBody]Login command)
            {         
                 await CommandDispatcher.DispatchAsync(command);
                 var user= _context.Users.FirstOrDefault(x => x.Email == command.Email);
                 if(user == null)
                    return Unauthorized();
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)); 
                var creds =new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); 
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject= new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = creds
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor); 
                 return Ok(new {token= tokenHandler.WriteToken(token)});
                 
            }
       
        

    }
}