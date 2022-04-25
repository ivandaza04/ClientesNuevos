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
        List<UsuarioNuevo> UsuariosNuevos = new List<UsuarioNuevo>();

        public FacturaService(List<Factura> facturas)
        {
            Facturas = facturas;
        }

        public List<Factura> ConsultaFacturas()
        {
            return Facturas;
        }

        public List<Factura> ConsultaFacturasFecha(DateTime FechaMin, DateTime FechaMax)
        {
            foreach (Factura iteracion in Facturas)
                if (FacturaRangoFecha(iteracion.FechaCreacion, FechaMin, FechaMax) == true)
                {
                    IdAbogados.Add(iteracion);
                }

            return IdAbogados;
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

        public List<UsuarioNuevo> ConsultaIdAbogadoEsUsuarioNuevo(List<Factura> ListaIdAbogados, DateTime FechaMax)
        {
            var IdAbogadoContado = 0;
            foreach (Factura iteracion in ListaIdAbogados)
            {
                IdAbogadoContado = ContarIdAbogado(iteracion.IdAbogado, FechaMax);
                if (IdAbogadoContado == 1)
                    UsuariosNuevos.Add(new UsuarioNuevo(iteracion._id, iteracion.IdAbogado, iteracion.Codigo, iteracion.SubTotal, iteracion.FechaCreacion));
            }

            return UsuariosNuevos;
        }

        public int ContarIdAbogado(String IdAbogado, DateTime FechaMax)
        {
            var NIdAbogados = 0;
            foreach (Factura iteracion in Facturas)
                if (iteracion.IdAbogado == IdAbogado)
                {
                    if (DateTime.Compare(iteracion.FechaCreacion, FechaMax) <= 0)
                    {
                        NIdAbogados++;
                    }
                }

            return NIdAbogados;
        }

    }
}
