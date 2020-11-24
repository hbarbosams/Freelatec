using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Categoria
    {
        public int? Codigo{ get; set; }
        public string Descricao { get; set; }

        //Construtor 
        public Categoria()
        {
            Codigo = 0;
            Descricao = null;
        }
    }
}
