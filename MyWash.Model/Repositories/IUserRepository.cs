using System;
using System.Collections.Generic;
using MyWash.Model.Entity;

namespace MyWash.Model.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(Guid id, string user);
        IEnumerable<User> GetAll();
        void Create(User user);
        void Update(User user);        
        void Delete (User user);
    }
}