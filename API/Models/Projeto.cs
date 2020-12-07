using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Projeto
    {
        public int? idProjeto{ get; set; }
        public string descricaoProjeto{ get; set; }

        public Projeto()
        {
            idProjeto = 0;
            descricaoProjeto = null;
        }
    }
}
