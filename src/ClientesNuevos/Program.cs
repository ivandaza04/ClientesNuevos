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
            FacturaImplement FacturaImplement = new FacturaImplement();
            UsuarioNuevoImplement UsuarioNuevoImpl = new UsuarioNuevoImplement();


            FacturaService FacturaServicio = new FacturaService(FacturaImplement.GetFacturas());

            List<Factura> ListaFacturas = new List<Factura>();
            ListaFacturas = FacturaServicio.ConsultaFacturas();

            foreach (Factura F in ListaFacturas)
            {
                Console.WriteLine("Codigo Factura: " + F.Codigo + " Fecha: " + F.FechaCreacion);
            }
            
            List<Factura> ListaIdAbogadosFacturasEnFecha = new List<Factura>();
            // Facturas en el 5 del 2015
            var FechaMin = new DateTime(2015, 5, 1);
            var FechaMax = new DateTime(2015, 5, 30);
            ListaIdAbogadosFacturasEnFecha = FacturaServicio.ConsultaIdAbogados_FacturasFecha(FechaMin, FechaMax);
            Console.WriteLine("Todos los IdAbogados de facturas en Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura iteracion in ListaIdAbogadosFacturasEnFecha)
            {
                Console.WriteLine("IdAbogado: " + iteracion.IdAbogado);
            }

            List<UsuarioNuevo> ListaIdAbogadosUsuarioasNuevos = new List<UsuarioNuevo>();
            ListaIdAbogadosUsuarioasNuevos = FacturaServicio.ConsultaIdAbogados_FacturasFecha(ListaIdAbogadosFacturasEnFecha, FechaMax);
            Console.WriteLine("Todos los IdAbogados como usuarios nuevos en Fecha " + FechaMin + " - " + FechaMax);
            foreach (UsuarioNuevo iteracion in ListaIdAbogadosUsuarioasNuevos)
            {
                Console.WriteLine("IdAbogado Nuevos: " + iteracion.IdAbogado);
                UsuarioNuevoImpl.CreateUsuarioNuevo(iteracion);
            }
        }
    }
}
