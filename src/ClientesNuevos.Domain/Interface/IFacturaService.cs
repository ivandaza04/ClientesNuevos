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

        public List<Factura> ConsultaFacturasFecha(DateTime FechaMin, DateTime FechaMax);

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime FechaMin, DateTime FechaMax);

        public List<UsuarioNuevo> ConsultaIdAbogadoEsUsuarioNuevo(List<Factura> ListaAbogados, DateTime FechaMax);

        public int ContarIdAbogado(String IdAbogado, DateTime FechaMax);

    }
}
