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
            {
                Console.WriteLine("Codigo Factura: " + F.Codigo + " Fecha: " + F.FechaCreacion);
            }
            
            List<Factura> ListaIdAbogadosFacturasEnFecha = new List<Factura>();
            // Facturas en el 5 del 2015
            var FechaMin = new DateTime(2015, 5, 1);
            var FechaMax = new DateTime(2015, 5, 30);
            ListaIdAbogadosFacturasEnFecha = Servicio.ConsultaIdAbogados_FacturasFecha(FechaMin, FechaMax);
            Console.WriteLine("Todos los IdAbogados de facturas en Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura A in ListaIdAbogadosFacturasEnFecha)
            {
                Console.WriteLine("IdAbogado: " + A.IdAbogado);
            }

            List<Factura> ListaIdAbogadosUsuarioasNuevos = new List<Factura>();
            ListaIdAbogadosUsuarioasNuevos = Servicio.ConsultaIdAbogados_FacturasFecha(ListaIdAbogadosFacturasEnFecha, FechaMax);
            Console.WriteLine("Todos los IdAbogados como usuarios nuevos en Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura A in ListaIdAbogadosUsuarioasNuevos)
            {
                Console.WriteLine("IdAbogado Nuevos: " + A.IdAbogado);
            }
        }
    }
}
