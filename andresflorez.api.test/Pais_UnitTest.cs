using andresflorez.hotel.modelo.SqlServer;
using andresflorez.hotel.service.Implementacion;
using andresflorez.hotel.service.Wrapper;
using NUnit.Framework;
using System.Linq;

namespace andresflorez.api.test
{
    public class Tests
    {
        private PaisService paisService;
        private UsuarioService usuarioService;

        [SetUp]
        public void Setup()
        {
            paisService = new PaisService(new HotelDBContext());
            usuarioService = new UsuarioService(new HotelDBContext());
        }

        [Test]
        public void EsPaisColombia()
        {
            var result = paisService.GetPais(1);

            Assert.IsTrue(result.PaisNombre == "Colombia", "Id 1 es Colombia");
        }

        [Test]
        public void EsUsuarioSinCorreo()
        {
            var result = usuarioService.GetUsuario();
            var filtrado = result.Where(x => string.IsNullOrEmpty(x.UsuarioEmail));

            Assert.IsFalse(filtrado.Count() > 0, "Hay registros sin correo");
        }
    }
}