using andresflorez.hotel.modelo.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andresflorez.hotel.service.Contrato
{
    public interface IReservaService
    {
        Reserva GetReserva(int id);
        List<Reserva> GetReservaRangoFechas(bool estado, DateTime finicial, DateTime ffinal);
        void Crear(Reserva reserva);
        void Eliminar(int id);
    }
}
