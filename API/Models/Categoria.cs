using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Categoria
    {
        public int? codigo{ get; set; }
        public string descricao { get; set; }

        //Construtor 
        public Categoria()
        {
            codigo = 0;
            descricao = null;
        }
    }
}
