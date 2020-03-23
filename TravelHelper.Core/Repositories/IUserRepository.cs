using System.Collections.Generic;
using System;
using TravelHelper.Core.Domain;

namespace TravelHelper.Core.Repositories
{
    public interface IUserRepository
    {
         
        User Get(Guid id);
        User Get (string email);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);
    }
}