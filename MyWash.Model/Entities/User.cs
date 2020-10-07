using System;
using System.ComponentModel.DataAnnotations;

namespace MyWash.Model.Entity
{
    public class User
    {        
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
                
        [Key]
        public int Id { get; private set; }
        
        public string Name { get; private set; }
                
        public string Email { get; private set; }
              
        public string Password { get; private set; }

        public void defineNewPassword(string newPassword)
        {
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (newPassword.Equals(Password))
                    throw (new Exception("Senha não pode ser igual senha atual"));
                Password = newPassword;
            }           
            else
                throw (new Exception("Senha não pode ser vazia"));
        }

    }
}