using andresflorez.hotel.modelo.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andresflorez.hotel.service.Contrato
{
    public interface IPaisService
    {
        Pai GetPais(int id);
        List<Pai> GetPaises();

    }
}
