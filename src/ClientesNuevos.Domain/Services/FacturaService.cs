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

        public List<Factura> ConsultaFacturasFecha(DateTime fechaMin, DateTime fechaMax)
        {
            foreach (Factura factura in Facturas)
                if (FacturaRangoFecha(factura.FechaCreacion, fechaMin, fechaMax) == true)
                {
                    IdAbogados.Add(factura);
                }

            return IdAbogados;
        }

        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime fechaMin, DateTime fechaMax)
        {
            var FacturaAnteriorFechaMin = DateTime.Compare(FechaCreacion, fechaMin);
            var FacturaAnteriorFechaMax = DateTime.Compare(FechaCreacion, fechaMax);

            // Si la fecha Factura es mayor a FechaMin
            if (FacturaAnteriorFechaMin >= 0)
                // Si la fecha Factura es menor a FechaMax
                if (FacturaAnteriorFechaMax <= 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public List<UsuarioNuevo> ConsultaIdAbogadoEsUsuarioNuevo(List<Factura> ListaIdAbogados, DateTime fechaMax)
        {
            var IdAbogadoContado = 0;
            foreach (Factura factura in ListaIdAbogados)
            {
                IdAbogadoContado = ContarIdAbogado(factura.IdAbogado, fechaMax);
                if (IdAbogadoContado == 1)
                    UsuariosNuevos.Add(new UsuarioNuevo(factura._id, factura.IdAbogado, factura.Codigo, factura.SubTotal, factura.FechaCreacion));
            }

            return UsuariosNuevos;
        }

        public int ContarIdAbogado(String IdAbogado, DateTime fechaMax)
        {
            var NIdAbogados = 0;
            foreach (Factura factura in Facturas)
                if (factura.IdAbogado == IdAbogado)
                {
                    if (DateTime.Compare(factura.FechaCreacion, fechaMax) <= 0)
                    {
                        NIdAbogados++;
                    }
                }

            return NIdAbogados;
        }

    }
}
