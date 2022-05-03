using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class FacturaService
    {
        List<Factura> ListaFacturas;
        List<Factura> ListaFacturasFecha = new();
        List<UsuarioNuevo> ListaUsuariosNuevos = new();
        DateTime fechaMax;
        DateTime fechaMin;

        public FacturaService(List<Factura> listaFacturas, DateTime fechaMin, DateTime fechaMax)
        {
            ListaFacturas = listaFacturas;
            this.fechaMin = fechaMin;
            this.fechaMax = fechaMax;
        }

        public List<Factura> ConsultaFacturas()
        {
            return ListaFacturas;
        }

        // Valora todas las facturas de ListaFacturas si esta en las fechas establecidas y las agrega a ListaFacturasFecha
        public List<Factura> AgregaFacturasFecha()
        {
            foreach (Factura factura in ListaFacturas)
                if (FacturaRangoFecha(factura.FechaCreacion) == true)
                    ListaFacturasFecha.Add(factura);

            return ListaFacturasFecha;
        }

        // Valora si la FechaCreacion de la factura esta en rango de fechas
        public bool FacturaRangoFecha(DateTime FechaCreacion)
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
        public List<UsuarioNuevo> AgregarIdAbogadoEsUsuarioNuevo(List<Factura> ListaFacturasFecha)
        {
            var IdAbogadoContado = 0;
            foreach (Factura factura in ListaFacturasFecha)
            {
                IdAbogadoContado = ContarIdAbogado(factura.IdAbogado);
                if (IdAbogadoContado == 1)
                    ListaUsuariosNuevos.Add(new UsuarioNuevo(factura._id, factura.IdAbogado, factura.Codigo, factura.SubTotal, factura.FechaCreacion));
            }

            return ListaUsuariosNuevos;
        }

        // Valora cuantas veces IdAbogado esta presente en facturas de ListaFacturas 
        public int ContarIdAbogado(String IdAbogado)
        {
            var NumeroIdAbogados = 0;
            foreach (Factura factura in ListaFacturas)
                if (factura.IdAbogado == IdAbogado)
                {
                    NumeroIdAbogados = Contador(factura.FechaCreacion, NumeroIdAbogados);
                }

            return NumeroIdAbogados;
        }

        // Aumentar a uno si la fechaCreacion es menor a fechaMax
        public int Contador(DateTime fechaCreacion, int NumeroIdAbogados)
        {
            if (DateTime.Compare(fechaCreacion, fechaMax) <= 0)
            {
                NumeroIdAbogados++;
            }
            return NumeroIdAbogados;
        }

    }
}
