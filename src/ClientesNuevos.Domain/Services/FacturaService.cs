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
        List<Factura> ListaFacturas = new List<Factura>();
        List<Factura> ListaFacturasFecha = new List<Factura>();
        List<UsuarioNuevo> ListaUsuariosNuevos = new List<UsuarioNuevo>();

        public FacturaService(List<Factura> listaFacturas)
        {
            ListaFacturas = listaFacturas;
        }

        public List<Factura> ConsultaFacturas()
        {
            return ListaFacturas;
        }

        // Valora todas las facturas de ListaFacturas si esta en las fechas establecidas y las agrega a ListaFacturasFecha
        public List<Factura> ConsultaFacturasFecha(DateTime fechaMin, DateTime fechaMax)
        {
            foreach (Factura factura in ListaFacturas)
                if (FacturaRangoFecha(factura.FechaCreacion, fechaMin, fechaMax) == true)
                    ListaFacturasFecha.Add(factura);

            return ListaFacturasFecha;
        }

        // Valora si la FechaCreacion de la factura esta en rango de fechas
        public bool FacturaRangoFecha(DateTime FechaCreacion, DateTime fechaMin, DateTime fechaMax)
        {
            // Compara FechaCreacion con fechaMin, -1 es mayor, 0 es igual, 1 es mayor
            var FacturaAnteriorFechaMin = DateTime.Compare(FechaCreacion, fechaMin);
            // Compara FechaCreacion con fechaMax, -1 es mayor, 0 es igual, 1 es mayor
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

        // Valora si el IdAbogado de ListaFacturasFecha tiene facturas anteriores a fechaMax y las agrega UsuarioNuevo a ListaUsuariosNuevos
        public List<UsuarioNuevo> ConsultaIdAbogadoEsUsuarioNuevo(List<Factura> ListaFacturasFecha, DateTime fechaMax)
        {
            var IdAbogadoContado = 0;
            foreach (Factura factura in ListaFacturasFecha)
            {
                IdAbogadoContado = ContarIdAbogado(factura.IdAbogado, fechaMax);
                if (IdAbogadoContado == 1)
                    ListaUsuariosNuevos.Add(new UsuarioNuevo(factura._id, factura.IdAbogado, factura.Codigo, factura.SubTotal, factura.FechaCreacion));
            }

            return ListaUsuariosNuevos;
        }

        // Valora cuantas veces IdAbogado esta presente en facturas de ListaFacturas 
        public int ContarIdAbogado(String IdAbogado, DateTime fechaMax)
        {
            var NumeroIdAbogados = 0;
            foreach (Factura factura in ListaFacturas)
                if (factura.IdAbogado == IdAbogado)
                {
                    NumeroIdAbogados = Contador(factura.FechaCreacion, fechaMax, NumeroIdAbogados);
                }

            return NumeroIdAbogados;
        }

        // Aumentar a uno si la fechaCreacion es menor a fechaMax
        public int Contador(DateTime fechaCreacion, DateTime fechaMax, int NumeroIdAbogados)
        {
            if (DateTime.Compare(fechaCreacion, fechaMax) <= 0)
            {
                NumeroIdAbogados++;
            }
            return NumeroIdAbogados;
        }

    }
}
