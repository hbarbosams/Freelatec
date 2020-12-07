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

    public class ServicoController : Controller
    {
        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] List<Servico> servicos)
        {
                    
            using (var data = new ServicoData())
            foreach (var i in servicos){
                data.Create(i);
            }
            return Ok();
        }

       [Route("api/[controller]/ListaServico")]
       [HttpGet]
        public async Task<IActionResult> ListaServico(int nrContrato)
        {
            using (var data = new ServicoData())
            return Ok(data.LerContrato(nrContrato));  
        }        
    }
}
