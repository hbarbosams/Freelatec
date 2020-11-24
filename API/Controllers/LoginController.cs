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
             [HttpGet]
             public IActionResult Read(string login, string senha){
                 var freelancer = new Freelancer();
                 var contratante = new Contratante();
            using (var data = new FreelancerData())
            
                freelancer=data.Read(login);
                if ( freelancer != null && freelancer.Senha == senha){
                    return Ok(freelancer);
                }else{
                     using (var data1 = new ContratanteData())
                    contratante = data1.Read(login);
                    if ( contratante != null && contratante.Senha == senha){
                        return Ok(contratante);
                    }else{
                        return Ok();
                    }
                }                               
          }

         }

}