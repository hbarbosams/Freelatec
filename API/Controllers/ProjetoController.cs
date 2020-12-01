using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    public class ProjetoController : Controller
    {
        [Route("api/[controller]/Lista")]
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            using (var data = new ProjetoData())
                return Ok(data.Read());
        }
    }
}
