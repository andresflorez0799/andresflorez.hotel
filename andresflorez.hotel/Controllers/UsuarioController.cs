using andresflorez.hotel.service.Wrapper;
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
    [Produces("application/json")]
    public class UsuarioController : BaseControllerApi
    {
        public UsuarioController(IWrapperRepository wrapperRepository) : base(wrapperRepository)
        {
        }

        [HttpGet("id:int")]
        public IActionResult GetUsuarioById(int id) 
        {
            try
            {
                var modelo = repositorio.UsuarioWrapper.GetUsuario(id);
                if (modelo != null)
                    return new JsonResult(modelo);
                return NotFound("Sin resultado");
            }
            catch (Exception ex)
            {
                return GetErrorApi(ex);
            }
        }

        [HttpGet("")]//TODO: Mejorar que se pagine la peticion / respuesta
        public IActionResult GetUsuario()
        {
            try
            {
                var modelo = repositorio.UsuarioWrapper.GetUsuario();
                if (modelo != null)
                    return new JsonResult(modelo);
                return NotFound("Sin resultado");
            }
            catch (Exception ex)
            {
                return GetErrorApi(ex);
            }
        }

    }
}
