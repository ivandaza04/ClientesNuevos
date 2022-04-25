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
            // Declarar Implement para consultar en MongoDB
            FacturaImplement FacturaImplement = new FacturaImplement();
            UsuarioNuevoImplement UsuarioNuevoImpl = new UsuarioNuevoImplement();

            // Crear objetos para agregar a ListaFacturas
            FacturaService FacturaServicio = new FacturaService(FacturaImplement.GetFacturas());
            List<Factura> ListaFacturas = new List<Factura>();
            ListaFacturas = FacturaServicio.ConsultaFacturas();

            List<Factura> ListaIdAbogadosFacturasEnFecha = new List<Factura>();
            // Facturas en el 5 del 2015
            var FechaMin = new DateTime(2015, 4, 1);
            var FechaMax = new DateTime(2015, 5, 30);
            ListaIdAbogadosFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);
            // Imprime
            Console.WriteLine("Todos los IdAbogados de facturas en Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura iteracion in ListaIdAbogadosFacturasEnFecha)
            {
                Console.WriteLine("Codigo Factura: " + iteracion.Codigo + "\nFecha Creación: " + iteracion.FechaCreacion + "  IdAbogado: " + iteracion.IdAbogado + "\n");
            }

            // Extraer datos para agregar a ListaClienteNuevos
            UsuarioNuevoService UsuarioNuevoServicio = new UsuarioNuevoService(UsuarioNuevoImpl.GetClientesNuevos());
            List<UsuarioNuevo> ListaClienteNuevos = new List<UsuarioNuevo>();
            ListaClienteNuevos = UsuarioNuevoServicio.ConsultaClientesNuevos();
            // Imprime
            Console.WriteLine("Todos los Clientes Nuevos ya registrados en SGP");
            foreach (UsuarioNuevo iteracion in ListaClienteNuevos)
            {
                Console.WriteLine("IdAbogado " + iteracion.IdAbogado);
            }

            // Extraer datos para agregar a ListaUsuariosNuevos
            List<UsuarioNuevo> ListaUsuariosNuevos = new List<UsuarioNuevo>();
            ListaUsuariosNuevos = FacturaServicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaIdAbogadosFacturasEnFecha, FechaMax);
            // Imprime
            Console.WriteLine("Todos los IdAbogados como usuarios nuevos a registrar en Fecha " + FechaMin + " - " + FechaMax);
            foreach (UsuarioNuevo iteracion in ListaUsuariosNuevos)
            {
                Console.WriteLine("IdAbogado Nuevos: " + iteracion.IdAbogado);
                UsuarioNuevoImpl.CreateUsuarioNuevo(iteracion);
            }

        }
    }
}
