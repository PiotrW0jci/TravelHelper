using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TravelHelper.Infrastructure.DTO;
using TravelHelper.Infrastructure.Extensions;
using TravelHelper.Infrastructure.Settings;

namespace TravelHelper.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        
       // private readonly JwtSettings _settings;
      //  {
        //    _settings = settings;
     //   }

        public JwtDto CreateToken(string email)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

           // var expires = now.AddMinutes(double min =5.0);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xecretKeywqejane")), 
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                claims: claims,
                notBefore: now,
                //expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
               // Expires = expires.ToTimestamp()
            };
        }
    }
}
