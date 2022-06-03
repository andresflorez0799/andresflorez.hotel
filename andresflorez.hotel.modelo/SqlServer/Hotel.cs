using System;
using System.Collections.Generic;

#nullable disable

namespace andresflorez.hotel.modelo.SqlServer
{
    public partial class Hotel
    {
        public Hotel()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public int IdPais { get; set; }
        public string HotelNombre { get; set; }
        public decimal? HotelLatitud { get; set; }
        public decimal? HotelLongitud { get; set; }
        public string HotelDescripcion { get; set; }
        public bool? HotelActivo { get; set; }
        public int HotelNumeroHabitaciones { get; set; }

        public virtual Pai IdPaisNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
