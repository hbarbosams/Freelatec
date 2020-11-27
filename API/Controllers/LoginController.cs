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
            
                freelancer=data.Read(pessoa.Login);
                if ( freelancer != null && freelancer.Senha == pessoa.Senha && freelancer.Login == pessoa.Login){
                    return Ok(freelancer);
                }else{
                     using (var data1 = new ContratanteData())
                    contratante = data1.Read(pessoa.Login);
                    if ( contratante != null && contratante.Senha == pessoa.Senha && contratante.Login == pessoa.Login){
                        return Ok(contratante);
                    }else{
                        return Ok();
                    }
                }                               
          }

         }

}