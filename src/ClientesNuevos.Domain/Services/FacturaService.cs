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
                AgregaFactura(factura);

            return ListaFacturasFecha;
        }

        public void AgregaFactura(Factura factura)
        {
            RangoFechaService rangoFecha = new RangoFechaService(fechaMin, fechaMax);
            if (rangoFecha.ValidarRangoFecha(factura.FechaCreacion) == true)
                ListaFacturasFecha.Add(factura);
        }

        // Valora si el IdAbogado de ListaFacturasFecha tiene facturas anteriores a fechaMax y las agrega UsuarioNuevo a ListaUsuariosNuevos
        public List<UsuarioNuevo> AgregarIdAbogadoEsUsuarioNuevo(List<Factura> ListaFacturasFecha)
        {
            foreach (Factura factura in ListaFacturasFecha)
            {
                if (ContarIdAbogado(factura.IdAbogado) == 1)
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
