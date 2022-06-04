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
    public class PaisController : BaseControllerApi
    {
        public PaisController(IWrapperRepository wrapperRepository) : base(wrapperRepository)
        {
        }


        [HttpGet("id:int")]
        public IActionResult GetPaisById(int id)
        {
            try
            {
                var modelo = repositorio.PaisWrapper.GetPais(id);
                if (modelo != null)
                    return new JsonResult(modelo);
                return NotFound("Sin resultado");
            }
            catch (Exception ex)
            {
                return GetErrorApi(ex);
            }
        }

        [HttpGet("")]
        public IActionResult GetPaises()
        {
            try
            {
                var modelo = repositorio.PaisWrapper.GetPaises();
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
