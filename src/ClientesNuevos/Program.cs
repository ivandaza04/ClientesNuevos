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
            Console.WriteLine("Facturas!");
            // Declarar Implement para consultar en MongoDB
            FacturaImplement FacturaImpl = new();
            UsuarioNuevoImplement UsuarioNuevoImpl = new();
            AbogadoImplement AbogadoImpl = new();
            ProcesoImplement ProcesoImpl = new();
            ProcesoTybaImplement ProcesoTybaImpl = new();

            Console.WriteLine("Espere...!");
            // Lista de Todas las Facturas en ListaFacturas
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());
            List<Factura> ListaFacturas = new List<Factura>();
            ListaFacturas = FacturaServicio.ConsultaFacturas();

            // Ingrese Fechas
            var FechaMin = new DateTime();
            var FechaMax = new DateTime();

            try
            {
                Console.WriteLine("Ingrese Fecha Minima(AÑO.MES.DIA):");
                FechaMin = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Ingrese Fecha Maxima(AÑO.MES.DIA):");
                FechaMax = Convert.ToDateTime(Console.ReadLine());
            } catch (FormatException ex)
            {
                Console.WriteLine("Error Fecha Invalida");
            }

            // Lista de Facturas en las Fechas Establecidas en ListaFacturasEnFecha
            List<Factura> ListaFacturasEnFecha = new List<Factura>();
            ListaFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);
            Console.WriteLine("Todos las facturas en la Fecha " + FechaMin + " - " + FechaMax);
            foreach (Factura factura in ListaFacturasEnFecha)
            {
                Console.WriteLine("Codigo Factura: " + factura.Codigo + "\nFecha Creación: " + factura.FechaCreacion + "  IdAbogado: " + factura.IdAbogado + "\n");
            }

            // Lista Usuarios Nuevos en las Fecha Establecida en ListaUsuariosNuevos e inserta en ClientesNuevos
            List<UsuarioNuevo> ListaUsuariosNuevos = new List<UsuarioNuevo>();
            ListaUsuariosNuevos = FacturaServicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaFacturasEnFecha, FechaMax);
            // Imprime
            Console.WriteLine("Todos los IdAbogados como usuarios nuevos a registrar en Fecha " + FechaMin + " - " + FechaMax);
            foreach (UsuarioNuevo usuario in ListaUsuariosNuevos)
            {
                Console.WriteLine("IdAbogado Nuevos: " + usuario.IdAbogado);
                UsuarioNuevoImpl.CreateUsuarioNuevo(usuario);
            }

            // Lista Consulta Todos Cliente Nuevos en SGP en ListaClienteNuevos
            UsuarioNuevoService UsuarioNuevoServicio = new(UsuarioNuevoImpl.GetClientesNuevos());
            List<UsuarioNuevo> ListaClienteNuevos = new List<UsuarioNuevo>();
            ListaClienteNuevos = UsuarioNuevoServicio.ConsultaClientesNuevos();
            // Imprime
            Console.WriteLine("Todos los Clientes Nuevos ya registrados en SGP");
            foreach (UsuarioNuevo usuario in ListaClienteNuevos)
            {
                Console.WriteLine("IdAbogado " + usuario.IdAbogado);
            }

            // Lista Usuario Nuevos A Registrar que no esten en Clientes Nuevos en SGP en ListaUsuarios_A_Registrar
            List<UsuarioNuevo> ListaUsuarios_A_Registrar = new List<UsuarioNuevo>();
            ListaUsuarios_A_Registrar = UsuarioNuevoServicio.UsuariosNuevosRegistrar(ListaUsuariosNuevos);
            Console.WriteLine("Todos los Clientes Nuevos no registrados en SGP");
            foreach (UsuarioNuevo usuario in ListaUsuariosNuevos)
            {
                Console.WriteLine("IdAbogado " + usuario.IdAbogado);
            }

            // Consulta Info Abogados Email, Nombre, Activo y Ciudad
            AbogadoService AbogadoServicio = new(AbogadoImpl.GetAbogados());


            // Guardar informacion en un archivo csv de la lista ListaUsuariosNuevos
            var ArchivoCSV = new ArchivoCSV();
            Console.WriteLine("Ingrese Dirección Archivo:");
            var Direccion = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre Archivo:");
            var Nombre = Convert.ToString(Console.ReadLine());
            string Archivo = Direccion + "/" + Nombre + ".csv";

            Console.WriteLine("Espere...!");
            foreach (UsuarioNuevo usuario in ListaClienteNuevos)
            {
                var infoAbogado = AbogadoServicio.ConsultaAbogado(usuario.IdAbogado);
                var InformacionFila = "";
                if (infoAbogado != null)
                {
                    InformacionFila = usuario.IdAbogado + "," + usuario.CodigoFactura + "," + usuario.SubTotalFactura + "," + usuario.FechaCreacionFactura + "," + infoAbogado.Email + "," + infoAbogado.Activo + "," + infoAbogado.Nombre + "," + infoAbogado.Ciudad;
                } else
                {
                    InformacionFila = usuario.IdAbogado + "," + usuario.CodigoFactura + "," + usuario.SubTotalFactura + "," + usuario.FechaCreacionFactura + ",null,null,null,null";
                }
                var Procesos = ProcesoImpl.CuentaProcesos(usuario.IdAbogado);
                var ProcesoTyba = ProcesoTybaImpl.CuentaProcesoTyba(usuario.IdAbogado);
                InformacionFila = InformacionFila + "," + Procesos + "," + ProcesoTyba;

                ArchivoCSV.WriteCVS(Archivo, InformacionFila);
            }
            Console.WriteLine("proceso finalizado!");

        }
    }
}
