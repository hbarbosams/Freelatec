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
    [Route("api/Servico/[controller]")]
    [ApiController]

    public class ServicoController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection servico)
        {
            string descricao = servico["descricao"];
            double valor = Convert.ToDouble(servico["valor"]);

            if(descricao.Length < 20)
            {
                ViewBag.Mensagem1 = "Descrição deve conter pelo menos 20 caracteres";
                return View();
            }

            var novoServico = new Servico();

            novoServico.Descricao = servico["descricao"];
            novoServico.Valor = Convert.ToDouble(servico["valor"]);

            using (var data = new ServicoData())
                data.Create(novoServico);
            return View("Index");
        }
    }
}
