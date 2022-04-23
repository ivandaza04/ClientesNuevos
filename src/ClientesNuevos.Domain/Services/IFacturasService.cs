using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public interface IFacturasService
    {
        public List<Factura> ConsultaFacturas();

        public List<Factura> ConsultaFacturasFecha(DateTime fechaInicio, DateTime fechaFinal);

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime fechaInicio, DateTime fechaFinal);

    }
}
