using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Servico : Projeto
    {

        public int contratonr { get; set; }
        public decimal valor { get; set; }
        public string descricaoServico{ get; set; }

        public Servico()
        {
            contratonr = 0;
            valor = 0;
            descricaoServico = null;
        }
    }
}
