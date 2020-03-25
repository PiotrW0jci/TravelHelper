using System;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(string email);
    }
}