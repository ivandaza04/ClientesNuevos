using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class FacturasService : IFacturasService
    {
        List<Factura> Facturas = new List<Factura>();

        public FacturasService(List<Factura> facturas)
        {
            Facturas = facturas;
        }

        public List<Factura> ConsultaFacturas()
        {
            return Facturas;
        }

        public List<Factura> ConsultaFacturasFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            foreach (Factura factura in Facturas)
                if (FacturaRangoFecha(factura.FechaCreacion, fechaInicio, fechaFinal) != true)
                    Facturas.Remove(factura);

            return Facturas;
        }

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime fechaInicio, DateTime fechaFinal)
        {
            var FacturaAnteriorFecha1 = DateTime.Compare(FechaCreacion, fechaInicio);
            var FacturaAnteriorFecha2 = DateTime.Compare(FechaCreacion, fechaFinal);

            // Si la fecha Factura en mayor a Fecha1
            if (FacturaAnteriorFecha1 >= 0)
                // Si la fecha Factura en menor a Fecha2
                if (FacturaAnteriorFecha2 <= 0)
                    return true;
                else
                    return false;
            else
                return false;
        }
    }
}
