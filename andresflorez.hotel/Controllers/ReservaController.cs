using andresflorez.hotel.api.Models;
using andresflorez.hotel.modelo.SqlServer;
using andresflorez.hotel.service.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andresflorez.hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : BaseControllerApi
    {
        private readonly ILogger _logger;
        public ReservaController(IWrapperRepository wrapperRepository, ILogger<ReservaController> logger) : base(wrapperRepository)
        {
            _logger = logger;
        }

        /// <summary>
        /// Metodo de validacion api
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public IActionResult Index() => Ok("Api funcionando correctamente!!");

        /// <summary>
        /// Obtienes las reservas activas en un rango de fechas dado por parametro
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial</param>
        /// <param name="fechaFinal">Fecha final</param>
        /// <response code="404">No hay datos con los parametros dados</response>
        /// <response code="500">Error interno en el servidor o validacion de negocio</response>
        /// <returns>Listado de reservas</returns>
        [HttpGet("activas")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetReservasActivas([FromQuery] DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                var modelo = repositorio.ReservaWrapper.GetReservaRangoFechas(true, fechaInicial, fechaFinal);
                if (modelo != null && modelo.Count > 0) 
                {
                    var normalizar = modelo.Select(x => 
                    new 
                    { 
                        x.Id,
                        x.IdUsuario,
                        x.IdHotel,
                        x.ReservaFechaEntrada,
                        x.ReservaFechaSalida,
                        x.ReservaFechaReserva,
                        x.ReservaEstado,
                        x.IdHotelNavigation.HotelNombre,
                        x.IdUsuarioNavigation.UsuarioNombre,
                        x.IdUsuarioNavigation.UsuarioEmail
                    });
                    return new JsonResult(normalizar);
                }
                 

                return NotFound("Sin resultado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message, DateTime.UtcNow.ToLongTimeString());
                return GetErrorApi(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearReserva([FromBody] ReservaCrear reservaCrear) 
        {
            try
            {
                if (ModelState.IsValid && reservaCrear.Validar()) 
                {
                    var reservaNueva = new Reserva() 
                    {
                        IdUsuario = reservaCrear.IdUsuario,
                        IdHotel = reservaCrear.IdHotel,
                        IdHotelHabitacion = reservaCrear.IdHotelHabitacion,
                        ReservaFechaEntrada = reservaCrear.FechaEntrada,
                        ReservaFechaSalida = reservaCrear.FechaSalida,
                    };
                    repositorio.ReservaWrapper.Crear(reservaNueva);
                    return Ok();
                }
                return StatusCode(500, "Valide por favor el cuerpo de la peticion");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message, DateTime.UtcNow.ToLongTimeString());
                return GetErrorApi(ex);
            }
        }

        [HttpDelete("idReserva:int")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CancelarReserva(int idReserva)
        {
            try
            {
                repositorio.ReservaWrapper.Eliminar(idReserva);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError(ex.Message, DateTime.UtcNow.ToLongTimeString());
                return GetErrorApi(ex);
            }
        }

    }
}
