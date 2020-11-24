using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Servico
    {
        public double Valor { get; set; }
        public string Descricao{ get; set; }

        public Servico()
        {
            Valor = 0;
            Descricao = null;
        }
    }
}
