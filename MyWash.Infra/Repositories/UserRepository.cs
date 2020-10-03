using System;
using System.Collections.Generic;
using System.Linq;
using MyWash.Infra.Contexts;
using MyWash.Model.Entity;
using MyWash.Model.Repositories;

namespace MyWash.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyWashContext _context;
        public UserRepository(MyWashContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            if (user == null)
                throw (new ArgumentException(nameof(user)));
            
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }        

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }     
    }
}