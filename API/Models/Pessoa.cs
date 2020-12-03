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
        public int? id{ get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int status { get; set; }
        public string telefone{ get; set; }
        public int qtdProjetos{ get; set; }
        public decimal mediaNota{ get; set; }
        public string email { get; set; }

        public Pessoa()
        {
            id = 0;
            nome = null;
            login = null;
            senha = null;
            status = 0;
            telefone = null;
            qtdProjetos = 0;
            mediaNota = 0;
            email = null;
        }
    }
}
