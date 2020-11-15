using System;
using System.ComponentModel.DataAnnotations;

namespace MyWash.Model.Entity
{
    public class Cliente
    {
        public Cliente(int Id, string NomeCliente, int Cpf_Cnpj, int Telefone, string Email, string Endereço)
        {
            this.Id = Id;
            this.NomeCliente = NomeCliente;
            this.Cpf_Cnpj = Cpf_Cnpj;
            this.Telefone = Telefone;
            this.Email = Email;
            this.Endereço = Endereço;
        }

        [Key]

        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public int Cpf_Cnpj { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        public string Endereço { get; set; }
    }

    }
}