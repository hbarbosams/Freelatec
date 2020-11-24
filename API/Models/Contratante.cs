using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Contratante : Pessoa
    {
        public string Cnpj{ get; set; }
        public string AreaAtuacao{ get; set; }
        public string DescrContratante{ get; set; }

        public Contratante() : base()
        {
            Cnpj = null;
            AreaAtuacao = null;
            DescrContratante = null;

        }
    }
}
