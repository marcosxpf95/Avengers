using System;
using System.ComponentModel.DataAnnotations;

namespace MyWash.Model.Entity
{
    public class User
    {        
        public User() { }
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string defineNewPassword(string newPassword)
        {
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (newPassword.Equals(Password))
                    return "Senha não pode ser igual senha atual";

                Password = newPassword;
            }
            else
                return "Senha não pode ser vazia";

            return "Sucesso";
        }
    }
}