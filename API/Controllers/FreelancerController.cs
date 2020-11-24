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
    [Route("api/Freelancer/[controller]")]
    [ApiController]

    public class FreelancerController : Controller
    {
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection freelancer)
        {
            string nome = freelancer["nome"];   //<input name = "nome"
            string login = freelancer["login"]; //<input login = "login"
            string senha = freelancer["senha"]; //<input senha = "senha"
            string telefone = freelancer["telefone"]; //<input telefone = "telefone"
            string email = freelancer["email"]; //<input email = "email"

            string cpf = freelancer["cpf"];
            string ra = freelancer["ra"];
            string experiencia = freelancer["experiencia"];


            if (nome.Length < 3)
            {
                ViewBag.Mensagem1 = "Nome deve conter 3 ou mais caracteres";
                return View();
            }
            if (telefone.Length < 10)
            {
                ViewBag.Mensagem2 = "Telefone deve conter no mínimo 10 caracteres";
                return View();
            }
            if (login.Length < 6)
            {
                ViewBag.Mensagem3 = "Login deve conter 6 ou mais caracteres";
                return View();
            }
            if (!email.Contains("@"))
            {
                ViewBag.Mensagem4 = "Email inválido";
                return View();
            }
            if (senha.Length < 6)
            {
                ViewBag.Mensagem5 = "Senha deve conter 6 ou mais caracteres";
                return View();
            }
            var novoFreelancer = new Freelancer();
            novoFreelancer.Nome = freelancer["nome"];
            novoFreelancer.Login = freelancer["login"];
            novoFreelancer.Senha = freelancer["senha"];
            novoFreelancer.Status = 1;
            novoFreelancer.Telefone = freelancer["telefone"];
            novoFreelancer.QtdProjetos = 0;
            novoFreelancer.MediaNota = 0;
            novoFreelancer.Email = freelancer["email"];
            novoFreelancer.Cpf = freelancer["cpf"];
            novoFreelancer.Ra = freelancer["ra"];
            novoFreelancer.Experiencia = freelancer["experiencia"];

            using (var data = new FreelancerData())
                data.Create(novoFreelancer);
            return RedirectToAction("Index", novoFreelancer);
        }
    }
}
