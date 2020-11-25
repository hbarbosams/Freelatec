using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Pessoa
    {
        //Atributos
        public int? Id{ get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
        public string Telefone{ get; set; }
        public int QtdProjetos{ get; set; }
        public decimal MediaNota{ get; set; }
        public string Email { get; set; }

        public Pessoa()
        {
            Id = 0;
            Nome = null;
            Login = null;
            Senha = null;
            Status = 0;
            Telefone = null;
            QtdProjetos = 0;
            MediaNota = 0;
            Email = null;
        }
    }
}
