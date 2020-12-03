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
    [Route("api/Pessoa/[controller]")]
    [ApiController]

    public class PessoaController : Controller
    {
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection pessoa)
        {
            string nome = pessoa["nome"];   //<input name = "nome"
            string login = pessoa["login"]; //<input login = "login"
            string senha = pessoa["senha"]; //<input senha = "senha"
            string telefone = pessoa["telefone"]; //<input telefone = "telefone"
            string email = pessoa["email"]; //<input email = "email"
            

            if (nome.Length < 3)
            {
                ViewBag.Mensagem = "Nome deve conter 3 ou mais caracteres";
                return View();
            }
            if(telefone.Length < 10)
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
            var novaPessoa = new Pessoa();
            novaPessoa.nome = pessoa["nome"];
            novaPessoa.login = pessoa["login"];
            novaPessoa.senha = pessoa["senha"];
            novaPessoa.status = 1;
            novaPessoa.telefone = pessoa["telefone"];
            novaPessoa.qtdProjetos = 0;
            novaPessoa.mediaNota = 0;
            novaPessoa.email= pessoa["email"];
            
            using (var data = new PessoaData())
                data.Create(novaPessoa);
            return RedirectToAction("Index", novaPessoa);
        }
    }
}