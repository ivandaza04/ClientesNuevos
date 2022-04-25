using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public interface IFacturaService
    {
        public List<Factura> ConsultaFacturas();

        public List<Factura> ConsultaIdAbogados_FacturasFecha(DateTime FechaMin, DateTime FechaMax);

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime FechaMin, DateTime FechaMax);

        public List<UsuarioNuevo> ConsultaIdAbogados_FacturasFecha(List<Factura> ListaIdAbogados, DateTime FechaMax);

        public int ContarIdAbogado(String IdAbogado, DateTime FechaMax);

    }
}
