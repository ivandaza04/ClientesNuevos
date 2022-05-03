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
            SettingsDatabase settingsDatabase = new();
            FacturaImplement FacturaImpl = new(settingsDatabase);
            UsuarioNuevoImplement UsuarioNuevoImpl = new(settingsDatabase);
            AbogadoImplement AbogadoImpl = new(settingsDatabase);
            ProcesoImplement ProcesoImpl = new(settingsDatabase);
            ProcesoTybaImplement ProcesoTybaImpl = new(settingsDatabase);

            // Ingrese Fechas
            var FechaMin = new DateTime();
            var FechaMax = new DateTime();

            try
            {
                Console.WriteLine("Ingrese Fecha Minima(AÑO.MES.DIA):");
                FechaMin = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Ingrese Fecha Maxima(AÑO.MES.DIA):");
                FechaMax = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error Fecha Invalida");
            }

            Console.WriteLine("Espere...!");

            // Consulta Facturas en las fechas
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas(), FechaMin, FechaMax);
            List<Factura> ListaFacturasEnFecha = FacturaServicio.AgregaFacturasFecha();

            // Consulta UsuarioNuevo en las fechas
            List<UsuarioNuevo> ListaUsuariosNuevos = FacturaServicio.AgregarIdAbogadoEsUsuarioNuevo(ListaFacturasEnFecha);
            // Crear usuarios en colleccion ClientesNuevos de SGP
            foreach (UsuarioNuevo usuario in ListaUsuariosNuevos)
                {
                    UsuarioNuevoImpl.CreateUsuarioNuevo(usuario);
                }

            // ListaClienteNuevosFecha en colleccion ClientesNuevos
            UsuarioNuevoService UsuarioNuevoServicio = new(UsuarioNuevoImpl.GetClientesNuevos());
            List<UsuarioNuevo> ListaClienteNuevosFecha = UsuarioNuevoServicio.ConsultaClientesNuevosFecha(FechaMin, FechaMax);

            // Consulta Info Abogados Email, Nombre, Activo y Ciudad
            AbogadoService AbogadoServicio = new(AbogadoImpl.GetAbogados());

            // Guardar informacion en un archivo csv
            var ArchivoCSV = new ArchivoCSV();
            Console.WriteLine("Ingrese Dirección Archivo:");
            var Direccion = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre Archivo:");
            var Nombre = Convert.ToString(Console.ReadLine());
            string Archivo = Direccion + "/" + Nombre + ".csv";

            Console.WriteLine("Espere...!");
            foreach (UsuarioNuevo usuario in ListaClienteNuevosFecha)
            {
                var InformacionFila = "";
                var infoAbogado = AbogadoServicio.ConsultaAbogado(usuario.IdAbogado);
                if (infoAbogado != null)
                {
                    InformacionFila = usuario.IdAbogado + "," + usuario.CodigoFactura + "," + usuario.SubTotalFactura + "," + usuario.FechaCreacionFactura + "," + infoAbogado.Email + "," + infoAbogado.Activo + "," + infoAbogado.Nombre + "," + infoAbogado.Ciudad;
                }
                else
                {
                    InformacionFila = usuario.IdAbogado + "," + usuario.CodigoFactura + "," + usuario.SubTotalFactura + "," + usuario.FechaCreacionFactura + ",null,null,null,null";
                }
                var Procesos = ProcesoImpl.CuentaProcesos(usuario.IdAbogado);
                var ProcesoTyba = ProcesoTybaImpl.CuentaProcesoTyba(usuario.IdAbogado);
                InformacionFila = InformacionFila + "," + Procesos + "," + ProcesoTyba;

                ArchivoCSV.WriteCVS(Archivo, InformacionFila);
            }

            Console.WriteLine("Proceso finalizado!");

        }
    }
}
