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
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            if (user == null)
                throw (new ArgumentException(nameof(user)));

            var _user = GetUserById(user.Id);
            
            _user.Name = user.Name;
            _user.Email = user.Email;
            _user.defineNewPassword(user.Password);
            _context.SaveChanges();    
        }

        public void Delete(User user)
        {
            if (user == null)
                throw (new ArgumentException(nameof(user)));

            var _user = GetUserById(user.Id);
            _context.Users.Remove(user);
            _context.SaveChanges();

        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }        

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        
        public User GetUserAuthenticated(string name, string password)
        {
            var _user = _context.Users.Where(x => x.Name == name && x.Password == password).FirstOrDefault();

            return _user;
        }
    }
}