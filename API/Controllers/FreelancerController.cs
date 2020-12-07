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

        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Freelancer freelancer)
        {
            
            using (var data = new FreelancerData())
              data.Create(freelancer);
            return Ok (freelancer);
        }

        [Route("api/[controller]/CPF")]
        [HttpGet]
         public IActionResult CPF(string cpf){
             Freelancer freelancer = new Freelancer();
            using (var data = new FreelancerData())
             freelancer = data.CPF(cpf);
            return Ok(freelancer);
         }

         
        [Route("api/[controller]/Login")]
        [HttpGet]
         public IActionResult Login(string Login){
             Freelancer freelancer = new Freelancer();
            using (var data = new FreelancerData())
             freelancer = data.Login(Login);
            return Ok(freelancer);
         }

        [Route("api/[controller]/Email")]
        [HttpGet]
         public IActionResult Email(string Email){
             Freelancer freelancer = new Freelancer();
            using (var data = new FreelancerData())
             freelancer = data.Email(Email);
            return Ok(freelancer);
         }

        [Route("api/[controller]/Ra")]
        [HttpGet]
         public IActionResult Ra(string ra){
             Freelancer freelancer = new Freelancer();
            using (var data = new FreelancerData())
             freelancer = data.Ra(ra);
            return Ok(freelancer);
         }

        [Route("api/[controller]/Read")]
        [HttpGet]        
         public IActionResult Read(int id)
        {
             Freelancer resultado = new Freelancer();
                using (var data = new FreelancerData())
                resultado = data.LerDados(id);
                return  Ok(resultado);
        }

    }
}
