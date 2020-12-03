using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Freelancer : Pessoa
    {
        public string cpf{ get; set; }
        public string ra{ get; set; }
        public string experiencia{ get; set; }

        public Freelancer() : base()
        {
            cpf = null;
            ra = null;
            experiencia = null;
        }
    }
}
