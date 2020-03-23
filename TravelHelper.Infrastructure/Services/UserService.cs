using System;
using System.Reflection.Emit;
using TravelHelper.Core.Domain;
using TravelHelper.Core.Repositories;

namespace TravelHelper.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(string email,string username ,string password)
        {
            var user = _userRepository.Get(email);
            if(user!=null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            var salt= Guid.NewGuid().ToString("N");
            user = new User(email,username,password,salt);

        }
    }
}