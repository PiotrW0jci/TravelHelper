using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Core.Domain;
using TravelHelper.Core.Repositories;
using TravelHelper.Infrastructure.Data;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly DataContext _context;

        public UserService(IUserRepository userRepository,IEncrypter encrypter,IMapper mapper, DataContext context)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
            _context= context;
        }

       // public async Task<UserDto> GetAsync(string email)
       // {
         //   var user =  await _userRepository.GetAsync(email);
          //  return _mapper.Map<User,UserDto>(user);
     //   }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
            //var user = await _userRepository.GetAsync(email);
            if(user==null)
            {
                throw new Exception($"User with email: '{email}' does not exists.");
            }
            
            var hash = _encrypter.GetHash(password,user.Salt);
            if(user.Password == hash)
            {
                return user;
            }
            throw new Exception("Invalid credentials");
            
        }

        public async Task<User> RegisterAsync(string email,string username ,string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
            if(user!=null)
            {
               throw new Exception($"User with email: '{email}' already exists.");
            }
            var salt=  Guid.NewGuid().ToString("N");//_encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(email,username,hash,salt);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}