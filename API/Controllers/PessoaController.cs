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

    public class PessoaController : Controller
    {
        [Route("api/[controller]/Read")]
        [HttpGet]
        public IActionResult Read(int id)
        {
             Pessoa resultado = new Pessoa();
                using (var data = new PessoaData())
                resultado = data.Read(id);
                return  Ok(resultado);
        }

        [Route("api/[controller]/Update")]
        [HttpPost]
        public IActionResult Update(Pessoa pessoa)
        {
                using (var data = new PessoaData())
                data.Update(pessoa);
                return  Ok(pessoa);
        }

    }
}