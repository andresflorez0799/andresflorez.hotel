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
    public class PaisService : RepositorioBase<Pai>, IPaisService
    {
        public PaisService(DbContext context) : base(context)
        {
        }

        public Pai GetPais(int id) => FindById(id);

        public List<Pai> GetPaises() => FindAll().ToList();
        
    }
}
