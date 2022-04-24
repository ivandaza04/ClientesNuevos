using ClientesNuevos.Domain.Models;
using ClientesNuevos.Domain.Services;
using ClientesNuevos.Implement;
using System;
using System.Collections.Generic;

namespace ClientesNuevos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Imprimir Facturas!");
            FacturaImplement Implement = new FacturaImplement();
            FacturaService Servicio = new FacturaService(Implement.GetFacturas());

            List<Factura> ListaFacturas = new List<Factura>();
            ListaFacturas = Servicio.ConsultaFacturas();

            foreach (Factura F in ListaFacturas)
                Console.WriteLine("Codigo Factura: " + F.Codigo+" Fecha: "+F.FechaCreacion);

            
            List<Factura> ListaFacturasEnFecha = new List<Factura>();
            // Facturas en el 5 del 2015
            var fechaInicio = new DateTime(2015, 5, 1);
            var fechaFinal = new DateTime(2015, 5, 30);
            Console.WriteLine("Imprimir Facturas en Fecha "+fechaInicio+" - "+ fechaFinal);
            ListaFacturasEnFecha = Servicio.ConsultaFacturasFecha(fechaInicio, fechaFinal);
            foreach (Factura F in ListaFacturasEnFecha)
                Console.WriteLine("Codigo Factura: " + F.Codigo + " Fecha: " + F.FechaCreacion);
        }
    }
}
