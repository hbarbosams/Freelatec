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
    [Route("api/Contrato/[controller]")]
    [ApiController]


    public class ContratoController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection contrato, int id)
        {
            string descricao = contrato["descricao"];


            if (descricao.Length < 20)
            {
                ViewBag.Mensagem1 = "Descrição deve conter 20 ou mais caracteres";
                return View();
            }
            var novoContrato = new Contrato();
            novoContrato.Descricao = contrato["descricao"];
            novoContrato.Status = 1;
            novoContrato.NotaContratante = 0;
            novoContrato.NotaFreelancer = 0;
            novoContrato.Id = id;
            

            using (var data = new ContratoData())
                data.Create(novoContrato);
            return View("../Servico/Index");
        }
    }
}
