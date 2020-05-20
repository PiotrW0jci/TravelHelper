using System.IO;
using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{   
    public class User
    {

        
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        [Key]
         public Guid Id{ get; private set; }
        public string Email {get;protected set;}
        public string Password {get;protected set;}
        public string Salt {get;protected set;}
        public string Username {get;protected set;}
        public string FullName {get;protected set;}
        public string HashToActivate {get;protected set;}
       // public string Role { get; protected set; }
        public DateTime CreatedAt {get; protected set;}
        public DateTime UpdatedAt {get; protected set;}

        public bool IsActive {get; protected set;}
        protected User()
        {
        }
        public User(string email, string username,
        string password, string salt,string hashToActivate)
        {
            Id= Guid.NewGuid();
            Username= username;
            Email =email;
            Password =password;
            Salt=salt;
            CreatedAt= DateTime.UtcNow;
            IsActive = false;
            HashToActivate = hashToActivate;
        }

        public void SetUsername(string username)
        {
            if(!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new Exception( "Username is invalid.");
            }
            Username=username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetIsActive(bool active)
        {
            IsActive =active;
        }
        public void SetEmail(string email)
        {
          if (string.IsNullOrWhiteSpace(email)) 
            {
                throw new Exception( "Email can not be empty.");
            }
            if (Email == email) 
            {
                return;
            }

            email=email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
       public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }
            if (password.Length < 3) 
            {
                throw new Exception( "Password must contain at least 4 characters.");
            }
            if (password.Length > 100) 
            {
                throw new Exception(  "Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}