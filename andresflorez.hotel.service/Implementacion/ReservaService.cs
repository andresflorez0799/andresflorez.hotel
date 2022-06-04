using andresflorez.hotel.modelo.SqlServer;
using andresflorez.hotel.repositorio;
using andresflorez.hotel.service.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andresflorez.hotel.service.Implementacion
{
    public class ReservaService : RepositorioBase<Reserva>, IReservaService
    {
        public ReservaService(DbContext context) : base(context)
        {
        }
        public void Crear(Reserva reserva)
        {
            var consulta = FindByCondition(x => x.IdHotel == reserva.IdHotel
                && reserva.ReservaFechaEntrada >= x.ReservaFechaEntrada
                && reserva.ReservaFechaSalida < x.ReservaFechaSalida ///regla de negocio donde se dicta que el dia de salida no cuenta como parte de la reserva
                && x.IdHotelHabitacion == reserva.IdHotelHabitacion
                && x.ReservaEstado == true);

            ///SE valida que no exista ya una reserva en las fechas y hotel con la habitacion seleccionada
            if (consulta != null && consulta.Count() > 0)
                throw new Exception("ValidacionNegocio No puedes agendar, ya se encuentra separada");

            reserva.ReservaFechaReserva = DateTime.Now;
            reserva.ReservaEstado = true;
            Create(reserva);
        }

        public void Eliminar(int id)
        {
            var modelo = FindById(id);
            if (modelo != null && modelo.ReservaEstado == true)
            {
                modelo.ReservaEstado = false;
                Update(modelo);
            }
            else
                throw new Exception("ValidacionNegocio El registro no existe o no se puede cancelar");
        }

        public Reserva GetReserva(int id) => FindById(id);
        public List<Reserva> GetReservaRangoFechas(bool estado, DateTime finicial, DateTime ffinal)
        {
            if (finicial == DateTime.MinValue || finicial == DateTime.MaxValue)
                throw new Exception("ValidacionNegocio La fecha inicial no es valida");

            if (ffinal == DateTime.MinValue || ffinal == DateTime.MaxValue)
                throw new Exception("ValidacionNegocio La fecha inicial no es valida");

            if (finicial > ffinal)
                throw new Exception("ValidacionNegocio La fecha inicial no puede ser mayor a la final");

            return FindByCondition(
                    x => x.ReservaEstado == estado && x.ReservaFechaEntrada >= finicial && x.ReservaFechaSalida <= ffinal,
                    y => y.IdUsuarioNavigation,
                    z => z.IdHotelNavigation
                ).ToList();
        }
    }
}
