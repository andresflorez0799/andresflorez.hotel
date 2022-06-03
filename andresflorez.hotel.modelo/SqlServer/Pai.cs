using System;
using System.Collections.Generic;

#nullable disable

namespace andresflorez.hotel.modelo.SqlServer
{
    public partial class Pai
    {
        public Pai()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string PaisNombre { get; set; }
        public bool? PaisEstado { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
