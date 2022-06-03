using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andresflorez.hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OmegaResortController : ControllerBase
    {
        /// <summary>
        /// Metodo de validacion api
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        public IActionResult Index() => Ok("Api funcionando correctamente!!");
    }
}
