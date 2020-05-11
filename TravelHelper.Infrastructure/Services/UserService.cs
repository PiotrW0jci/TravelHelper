using System;
using System.Threading.Tasks;
using AutoMapper;
using TravelHelper.Core.Domain;
using TravelHelper.Core.Repositories;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

 //public UserService(IUserRepository userRepository,IEncrypter encrypter,IMapper mapper)  _encrypter = encrypter;
        public UserService(IUserRepository userRepository,IEncrypter encrypter,IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user =  await _userRepository.GetAsync(email);
            return _mapper.Map<User,UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user==null)
            {
                throw new Exception($"User with email: '{email}' does not exists.");
            }
            
            var hash = _encrypter.GetHash(password,user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
            
        }

        public async Task RegisterAsync(string email,string username ,string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user!=null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            var salt= _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(email,username,hash,salt);
            await _userRepository.AddAsync(user);

        }
    }
}