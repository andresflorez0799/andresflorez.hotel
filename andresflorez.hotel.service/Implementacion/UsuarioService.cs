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
    public class UsuarioService : RepositorioBase<Usuario>, IUsuarioService
    {
        public UsuarioService(DbContext context) : base(context)
        {
        }
        public Usuario GetUsuario(int id) => FindById(id);

    }
}
