using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Contrato
    {
        public int? nrContrato{ get; set; }
        public DateTime dataContrato{ get; set; }
        public double total{ get; set; }
        public string descricao { get; set; }
        public DateTime dataInicial { get; set; }
        public double notaContratante { get; set; }
        public double notaFreelancer{ get; set; }
        public DateTime prazo { get; set; }
        public int status { get; set; }
        public double taxa { get; set; }

        public Contrato()
        {
            nrContrato = 0;
            dataContrato = DateTime.Today;
            total = 0;
            descricao = null;
            dataInicial = DateTime.Today;
            notaContratante = 0;
            notaFreelancer = 0;
            prazo = DateTime.Today;
            status = 0;  
            taxa = 0;
        }

        public int Id { get; set; }
    }
}
