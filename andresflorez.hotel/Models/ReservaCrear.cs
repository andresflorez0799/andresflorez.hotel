using System;
using System.ComponentModel.DataAnnotations;

namespace andresflorez.hotel.api.Models
{
    public class ReservaCrear
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]
        public int IdHotelHabitacion { get; set; }
        [Required]
        public DateTime FechaEntrada { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }

        public bool Validar()
        {
            if (this.FechaEntrada <= DateTime.Now)
                return false;
            if (this.FechaSalida <= DateTime.Now)
                return false;
            if(this.FechaEntrada > this.FechaSalida)
                return false;
            if(this.FechaEntrada == DateTime.MinValue || this.FechaSalida == DateTime.MaxValue)
                return false;
            if (this.FechaSalida == DateTime.MinValue || this.FechaSalida == DateTime.MaxValue)
                return false;

            return true;
        }
    }
}
