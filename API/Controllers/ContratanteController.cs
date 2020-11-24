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
    public class ContratanteController : Controller
    {

        [Route("api/[controller]/Read")]
        [HttpGet]        
         public IActionResult Read(int id)

        {
            var resultado = new Contratante();
                using (var data = new ContratanteData())
                resultado = data.Read(id);
                return  Json(resultado);
        }

        [Route("api/[controller]/Create")]
        [HttpPost]

        public IActionResult Create(IFormCollection contratante)
        {
            string nome = contratante["nome"];   //<input name = "nome"
            string login = contratante["login"]; //<input login = "login"
            string senha = contratante["senha"]; //<input senha = "senha"
            string telefone = contratante["telefone"]; //<input telefone = "telefone"
            string email = contratante["email"]; //<input email = "email"

            string cnpj = contratante["cnpj"];
            string areaAtuacao = contratante["areaAtuacao"];
            string descrContratante = contratante["descrContratante"];

            if (nome.Length < 3)
            {
                ViewBag.Mensagem = "A razão social deve conter 3 ou mais caracteres";
                return View();
            }
            if (telefone.Length < 10)
            {
                ViewBag.Mensagem = "Telefone deve conter no mínimo 10 caracteres";
                return View();
            }
            if (login.Length < 6)
            {
                ViewBag.Mensagem = "Login deve conter 6 ou mais caracteres";
                return View();
            }
            if (!email.Contains("@"))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }
            if (senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter 6 ou mais caracteres";
                return View();
            }

            var novoContratante = new Contratante();

            novoContratante.Nome = contratante["nome"];
            novoContratante.Login = contratante["login"];
            novoContratante.Senha = contratante["senha"];
            novoContratante.Cnpj = contratante["cnpj"];
            novoContratante.Email = contratante["email"];
            novoContratante.AreaAtuacao = contratante["areaAtuacao"];
            novoContratante.Telefone = contratante["telefone"];
            novoContratante.MediaNota = 0;
            novoContratante.QtdProjetos = 0;
            novoContratante.Status = 1;
            novoContratante.DescrContratante = contratante["descrContratante"];

            using (var data = new ContratanteData())
                data.Create(novoContratante);
            return RedirectToAction("Index", novoContratante);
        }
    }
}
