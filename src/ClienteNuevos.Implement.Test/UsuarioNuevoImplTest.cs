using ClientesNuevos.Domain.Models;
using ClientesNuevos.Domain.Services;
using ClientesNuevos.Implement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteNuevos.Implement.Test
{
    public class UsuarioNuevoImplTest
    {
        [Test]
        public void CreateUsuarioNuevo()
        {
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            SettingsDatabase settingsDatabase = new();
            FacturaImplement FacturaImpl = new(settingsDatabase);
            UsuarioNuevoImplement UsuarioNuevoImpl = new(settingsDatabase);
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas(), FechaMin, FechaMax);

            
            List<Factura> ListaFacturasEnFecha = FacturaServicio.AgregaFacturasFecha();

            // ListaUsuariosNuevos del mes de Abril
            List<UsuarioNuevo> ListaUsuariosNuevos = FacturaServicio.AgregarIdAbogadoEsUsuarioNuevo(ListaFacturasEnFecha);

            // Crear usuarios en tabla ClientesNuevos de SGP
            foreach (UsuarioNuevo usuario in ListaUsuariosNuevos)
            {
                UsuarioNuevoImpl.CreateUsuarioNuevo(usuario);
            }

            List<UsuarioNuevo> ListaClienteNuevos = UsuarioNuevoImpl.GetClientesNuevos();
            // Se registraron 5 usuarios nuevo de Abril en ClientesNuevos
            var result = 5;

            Assert.IsNotNull(ListaClienteNuevos);
            Assert.AreEqual(result, ListaClienteNuevos.Count);
        }

    }
}
