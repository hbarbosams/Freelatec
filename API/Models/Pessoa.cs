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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }


        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo login obrigatório")]
        [MinLength(6)]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha obrigatório")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public int Status { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo telefone obrigatório")]
        [MinLength(10)]
        public string Telefone{ get; set; }
        public int QtdProjetos{ get; set; }
        public decimal MediaNota{ get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo email obrigatório")]
        [DataType(DataType.EmailAddress)]
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
