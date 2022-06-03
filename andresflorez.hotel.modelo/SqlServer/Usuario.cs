using System;
using System.Collections.Generic;

#nullable disable

namespace andresflorez.hotel.modelo.SqlServer
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioDireccion { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
