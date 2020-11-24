using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Freelancer : Pessoa
    {
        public string Cpf{ get; set; }
        public string Ra{ get; set; }
        public string Experiencia{ get; set; }

        public Freelancer() : base()
        {
            Cpf = null;
            Ra = null;
            Experiencia = null;
        }
    }
}
