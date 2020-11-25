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

    public class FreelancerController : Controller
    {

        [Route("api/[controller]/Create")]
        [HttpPost]
        public IActionResult Create([FromBody] Freelancer freelancer)
        {
            
            using (var data = new FreelancerData())
              data.Create(freelancer);
            return Ok (freelancer);
        }
    }
}
