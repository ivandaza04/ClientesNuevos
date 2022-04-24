using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class FacturaService : IFacturaService
    {
        List<Factura> Facturas = new List<Factura>();

        public FacturaService(List<Factura> facturas)
        {
            Facturas = facturas;
        }

        public List<Factura> ConsultaFacturas()
        {
            return Facturas;
        }

        public List<Factura> ConsultaFacturasFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            var FacturasEnFecha = new List<Factura>();
            foreach (Factura F in Facturas)
                if (FacturaRangoFecha(F.FechaCreacion, fechaInicio, fechaFinal) == true)
                {
                    FacturasEnFecha.Add(F);
                }

            return FacturasEnFecha;
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
