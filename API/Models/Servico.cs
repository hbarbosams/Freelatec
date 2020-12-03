using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Servico
    {
        public double valor { get; set; }
        public string descricao{ get; set; }

        public Servico()
        {
            valor = 0;
            descricao = null;
        }
    }
}
