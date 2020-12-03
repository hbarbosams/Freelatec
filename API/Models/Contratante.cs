using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Contratante : Pessoa
    {
        public string cnpj{ get; set; }
        public string areaAtuacao{ get; set; }
        public string descrContratante{ get; set; }

        public Contratante() : base()
        {
            cnpj = null;
            areaAtuacao = null;
            descrContratante = null;

        }
    }
}
