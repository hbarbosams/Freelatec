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
                resultado = data.LerDados(id);
                return  Ok(resultado);
        }

        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Contratante contratante)
        {
            string nome = contratante.nome;   //<input name = "nome"
            string login = contratante.login; //<input login = "login"
            string senha = contratante.senha; //<input senha = "senha"
            string telefone = contratante.telefone; //<input telefone = "telefone"
            string email = contratante.email; //<input email = "email"
            string cnpj = contratante.cnpj;
            string areaAtuacao = contratante.areaAtuacao;
            string descrContratante = contratante.descrContratante;

            using (var data = new ContratanteData())
                data.Create(contratante);
            return Ok(contratante);
        }

        [Route("api/[controller]/CNPJ")]
        [HttpGet]
         public IActionResult CNPJ(string cnpj){
             Contratante contratante = new Contratante();
            using (var data = new ContratanteData())
             contratante = data.Cnpj(cnpj);
            return Ok(contratante);
         }

    }
}
