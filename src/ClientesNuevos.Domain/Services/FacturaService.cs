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
        List<Factura> IdAbogados = new List<Factura>();
        List<Factura> UsuariosNuevos = new List<Factura>();

        public FacturaService(List<Factura> facturas)
        {
            Facturas = facturas;
        }

        public List<Factura> ConsultaFacturas()
        {
            return Facturas;
        }

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime FechaMin, DateTime FechaMax)
        {
            var FacturaAnteriorFechaMin = DateTime.Compare(FechaCreacion, FechaMin);
            var FacturaAnteriorFechaMax = DateTime.Compare(FechaCreacion, FechaMax);

            // Si la fecha Factura en mayor a Fecha1
            if (FacturaAnteriorFechaMin >= 0)
                // Si la fecha Factura en menor a Fecha2
                if (FacturaAnteriorFechaMax <= 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public List<Factura> ConsultaIdAbogados_FacturasFecha(DateTime FechaMin, DateTime FechaMax)
        {
            foreach (Factura F in Facturas)
                if (FacturaRangoFecha(F.FechaCreacion, FechaMin, FechaMax) == true)
                {
                    IdAbogados.Add(F);
                }

            return IdAbogados;
        }

        public List<Factura> ConsultaIdAbogados_FacturasFecha(List<Factura> ListaIdAbogados, DateTime FechaMax)
        {
            var IdAbogadoContado = 0;
            foreach (Factura A in ListaIdAbogados)
            {
                IdAbogadoContado = ContarIdAbogado(A.IdAbogado, FechaMax);
                if (IdAbogadoContado == 1)
                    UsuariosNuevos.Add(A);
            }

            return UsuariosNuevos;
        }

        public int ContarIdAbogado(String IdAbogado, DateTime FechaMax)
        {
            var NIdAbogados = 0;
            foreach (Factura F in Facturas)
                if (F.IdAbogado == IdAbogado)
                {
                    if (DateTime.Compare(F.FechaCreacion, FechaMax) <= 0)
                    {
                        NIdAbogados++;
                    }
                }

            return NIdAbogados;
        }

    }
}
