using System.IO;
using System;
using System.Text.RegularExpressions;

namespace TravelHelper.Core.Domain
{   
    public class User
    {

        
private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public Guid Id;
        public string Email {get;protected set;}
        public string Password {get;protected set;}
        public string Salt {get;protected set;}
        public string Username {get;protected set;}
        public string FullName {get;protected set;}
        public DateTime CreatedAt {get; protected set;}
        public DateTime UpdatedAt {get; protected set;}

        public bool IsActive {get; protected set;}
        protected User()
        {
        }
        public User(string email, string username,
        string password, string salt)
        {
            Id= Guid.NewGuid();
            Email=email.ToLowerInvariant();
            Username=username;
            Password = password;
            Salt = salt;
            CreatedAt= DateTime.UtcNow;
            IsActive = false;
        }

        public void SetUsername(string username)
        {
            if(!NameRegex.IsMatch(username))
            {
                 
                
            }
        }
    }
}