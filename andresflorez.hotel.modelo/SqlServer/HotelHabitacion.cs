using System;
using System.Collections.Generic;

#nullable disable

namespace andresflorez.hotel.modelo.SqlServer
{
    public partial class HotelHabitacion
    {
        public HotelHabitacion()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string HotelHabitacionCodigo { get; set; }
        public bool? HotelHabitacionEstado { get; set; }

        public virtual Hotel IdHotelNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
