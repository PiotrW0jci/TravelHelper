using System;
using System.Net;
using System.Net.Mail;
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
        private readonly IEmailSender _emailSender;
        private readonly IEncrypter _encrypter;
        private readonly DataContext _context;
     

        public UserService(IUserRepository userRepository,IEmailSender emailSender,IEncrypter encrypter,IMapper mapper, DataContext context)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
            _emailSender = emailSender;
            _context= context;
        
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
            
            if(user==null)
            {
                throw new Exception($"User with email: '{email}' does not exists.");
            }
            
            var hash = _encrypter.GetHash(password,user.Salt);
            if(user.Password == hash && user.IsActive)
            {
                return user;
            }
            
            throw new Exception("Invalid credentials");
            
        }
        public async Task<User> ActivateUserAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.HashToActivate == token);
            if(user==null)
            {
               throw new Exception($"wrong url");
            }
            
            user.SetIsActive(true);
            await _context.SaveChangesAsync();

            return user;
        }
    
        public async Task<User> RegisterAsync(string email,string username ,string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == email);
            if(user!=null)
            {
               throw new Exception($"User with email: '{email}' already exists.");
            }
            var salt=  _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            var hashActivate=  _encrypter.GetActivate(password);
            user = new User(email,username,hash,salt,hashActivate);
            await  _emailSender.SendActivateEmail(email,hashActivate);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> ChangeUserPasswordAsync(string id, string password, string newPassword)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
            var salt=  _encrypter.GetSalt(newPassword);
            var hash = _encrypter.GetHash(newPassword,salt);
            user.Password=hash;
            _context.SaveChangesAsync();
            return user;

        }
    }
}