using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    [ApiController]  
    public class ContratanteController : Controller
    {
        [Route("api/[controller]/Read")]
        [HttpGet]        
         public IActionResult Read(int id)

        {
            var resultado = new Contratante();
                using (var data = new ContratanteData())
                resultado = data.Read(id);
                return  Ok(resultado);
        }

        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Contratante contratante)
        {
            string nome = contratante.Nome;   //<input name = "nome"
            string login = contratante.Login; //<input login = "login"
            string senha = contratante.Senha; //<input senha = "senha"
            string telefone = contratante.Telefone; //<input telefone = "telefone"
            string email = contratante.Email; //<input email = "email"
            string cnpj = contratante.Cnpj;
            string areaAtuacao = contratante.AreaAtuacao;
            string descrContratante = contratante.DescrContratante;

            using (var data = new ContratanteData())
                data.Create(contratante);
            return Ok(contratante);
        }
    }
}
