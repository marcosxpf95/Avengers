using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWash.Model.Entity
{
    public class User
    {        
        public User() { }
   
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        
        [NotMapped]
        public string Token { get; set; }

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