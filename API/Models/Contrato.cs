using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Contrato
    {
        public int? NrContrato{ get; set; }
        public DateTime DataContrato{ get; set; }
        public double Total{ get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public double NotaContratante { get; set; }
        public double NotaFreelancer{ get; set; }
        public DateTime Prazo { get; set; }
        public int Status { get; set; }
        public double Taxa { get; set; }

        public Contrato()
        {
            NrContrato = 0;
            DataContrato = DateTime.Today;
            Total = 0;
            Descricao = null;
            DataInicial = DateTime.Today;
            NotaContratante = 0;
            NotaFreelancer = 0;
            Prazo = DateTime.Today;
            Status = 0;  
            Taxa = 0;
        }

        public int Id { get; set; }
    }
}
