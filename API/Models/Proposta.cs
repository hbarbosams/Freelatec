using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Proposta
    {
        public double TotalProposto{ get; set; }
        public string Descricao{ get; set; }
        public DateTime Prazo { get; set; }

        public Proposta()
        {
            TotalProposto = 0;
            Descricao = null;
            Prazo = DateTime.Today;
        }
    }
}
