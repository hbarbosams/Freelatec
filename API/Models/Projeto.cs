using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Projeto
    {
        public int? IdProjeto{ get; set; }
        public string Descricao{ get; set; }

        public Projeto()
        {
            IdProjeto = 0;
            Descricao = null;
        }
    }
}
