using andresflorez.hotel.service.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andresflorez.hotel.service.Wrapper
{
    public interface IWrapperRepository
    {
        IUsuarioService UsuarioWrapper { get; }
        IPaisService PaisWrapper { get; }
        IReservaService ReservaWrapper { get; }
    }
}
