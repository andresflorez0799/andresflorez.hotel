using andresflorez.hotel.modelo.SqlServer;
using andresflorez.hotel.service.Contrato;
using andresflorez.hotel.service.Implementacion;

namespace andresflorez.hotel.service.Wrapper
{
    /// <summary>
    /// Calse wrapper o proveedor de instancias del service
    /// </summary>
    public class WrapperRepository : IWrapperRepository
    {
        //Instancia del contexto de EF
        private readonly HotelDBContext _hotelContexto;

        private IUsuarioService _usuarioService;
        private IPaisService _paisService;

        public WrapperRepository() => _hotelContexto = new();

        public IUsuarioService UsuarioWrapper
        {
            get
            {
                if (_usuarioService is null)
                    _usuarioService = new UsuarioService(_hotelContexto);
                return _usuarioService;
            }
        }

        public IPaisService PaisWrapper
        {
            get
            {
                if (_paisService is null)
                    _paisService = new PaisService(_hotelContexto);
                return _paisService;
            }
        }
    }
}
