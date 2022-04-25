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

            // Ingrese Fechas
            var FechaMin = new DateTime();
            var FechaMax = new DateTime();
            Console.WriteLine("Ingrese Fecha Minima(AÑO.MES.DIA):");
            FechaMin = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese Fecha Maxima(AÑO.MES.DIA):");
            FechaMax = Convert.ToDateTime(Console.ReadLine());

            List<Factura> ListaIdAbogadosFacturasEnFecha = new List<Factura>();
            ListaIdAbogadosFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);
            // Imprime
            Console.WriteLine("Todos los IdAbogados de facturas en Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura iteracion in ListaIdAbogadosFacturasEnFecha)
            {
                Console.WriteLine("Codigo Factura: " + iteracion.Codigo + "\nFecha Creación: " + iteracion.FechaCreacion + "  IdAbogado: " + iteracion.IdAbogado + "\n");
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

            // Guardar informacion en un archivo csv
            var ArchivoCSV = new ArchivoCSV();
            Console.WriteLine("Ingrese Dirección Archivo:");
            var Direccion = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre Archivo:");
            var Nombre = Convert.ToString(Console.ReadLine());
            string Archivo = Direccion + "/" + Nombre + ".csv";
            var InformacionFila = "";
            foreach (UsuarioNuevo iteracion in ListaClienteNuevos)
            {
                InformacionFila = iteracion.IdAbogado + "," + iteracion.CodigoFactura + "," + iteracion.SubTotalFactura + "," + iteracion.FechaCreacionFactura;
                ArchivoCSV.WriteCVS(Archivo, InformacionFila);
            }
        }
    }
}
