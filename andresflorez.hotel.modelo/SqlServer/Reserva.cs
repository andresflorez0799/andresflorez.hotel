using System;
using System.Collections.Generic;

#nullable disable

namespace andresflorez.hotel.modelo.SqlServer
{
    public partial class Reserva
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdHotel { get; set; }
        public int? IdHotelHabitacion { get; set; }
        public DateTime? ReservaFechaEntrada { get; set; }
        public DateTime? ReservaFechaSalida { get; set; }
        public DateTime? ReservaFechaReserva { get; set; }
        public bool? ReservaEstado { get; set; }

        public virtual HotelHabitacion IdHotelHabitacionNavigation { get; set; }
        public virtual Hotel IdHotelNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
