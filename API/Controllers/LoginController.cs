using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController] 
         public class LoginController : Controller{

        [Route("api/[controller]/Read")]
             [HttpPost]
             public IActionResult Read([FromBody] Pessoa pessoa){
                 var freelancer = new Freelancer();
                 var contratante = new Contratante();

            using (var data = new FreelancerData())
            
                freelancer=data.Read(pessoa.login);
                if ( freelancer != null && freelancer.senha == pessoa.senha && freelancer.login == pessoa.login){
                    return Ok(freelancer);
                }else{
                     using (var data1 = new ContratanteData())
                    contratante = data1.Read(pessoa.login);
                    if ( contratante != null && contratante.senha == pessoa.senha && contratante.login == pessoa.login){
                        return Ok(contratante);
                    }else{
                        return Ok();
                    }
                }                               
          }

         }

}