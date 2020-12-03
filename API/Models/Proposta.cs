using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Proposta
    {
        public double totalProposto{ get; set; }
        public string descricao{ get; set; }
        public DateTime prazo { get; set; }

        public Proposta()
        {
            totalProposto = 0;
            descricao = null;
            prazo = DateTime.Today;
        }
    }
}
