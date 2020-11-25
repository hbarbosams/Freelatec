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
    public class FreelancerController : Controller
    {
        [Route("api/[controller]/Read")]
        [HttpGet]        
         public IActionResult Read(int id)

        {
            var resultado = new Freelancer();
                using (var data = new FreelancerData())
                resultado = data.Read(id);
                return  Ok(resultado);
        }

        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Freelancer freelancer)
        {
            string nome = freelancer.Nome;   //<input name = "nome"
            string login = freelancer.Login; //<input login = "login"
            string senha = freelancer.Senha; //<input senha = "senha"
            string telefone = freelancer.Telefone; //<input telefone = "telefone"
            string email = freelancer.Email; //<input email = "email"
            string cpf = freelancer.Cpf;
            string ra = freelancer.Ra;
            string experiencia = freelancer.Experiencia;

            using (var data = new FreelancerData())
                data.Create(freelancer);
            return Ok(freelancer);
        }
    }
}
