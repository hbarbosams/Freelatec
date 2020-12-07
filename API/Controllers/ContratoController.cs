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


    public class ContratoController : Controller
    {
        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Contrato contrato)
        {
            Contrato novoContrato = new Contrato();
             using (var data = new ContratoData())
             novoContrato = data.Create(contrato);

             return Ok(novoContrato);
    }
        [Route("api/[controller]/CreateProjetos")]
        [HttpPost]
        public IActionResult CreateProjetos([FromBody] List<Projeto> projetos)
        {
            
             using (var data = new ServicoData())
             foreach (Projeto i in projetos ){

             }
             return Ok();
    }

        [Route("api/[controller]/Lista")]
        [HttpGet]
        public async Task<IActionResult> Lista()
        {   
            Contrato novoContrato = new Contrato();
            using (var data = new ContratoData())
             return Ok(data.Read());
             
    }

        [Route("api/[controller]/ListaFreelancer")]
        [HttpGet]
        public async Task<IActionResult> ListaFreelancer(int id)
        {   
            Contrato novoContrato = new Contrato();
            using (var data = new ContratoData())
             return Ok(data.ReadFreelancer(id));
             
    }
      [Route("api/[controller]/Update")]
      [HttpPost]
        public async Task<IActionResult> Update([FromBody] Contrato contrato)
        {   
            using (var data = new ContratoData())
            data.Update(contrato);
             return Ok(contrato);
        }

        [Route("api/[controller]/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Contrato contrato)
        {   
            using (var data = new ContratoData())
            data.Delete(contrato);
             return Ok(contrato);
        }

    }
}
