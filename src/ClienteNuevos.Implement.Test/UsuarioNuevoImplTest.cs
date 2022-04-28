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
            FacturaImplement FacturaImpl = new();
            UsuarioNuevoImplement UsuarioNuevoImpl = new();
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());

            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);
            List<Factura> ListaFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);

            // ListaUsuariosNuevos del mes de Abril
            List<UsuarioNuevo> ListaUsuariosNuevos = FacturaServicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaFacturasEnFecha, FechaMax);

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

        [Test]
        public void ConsultarClientesNuevos()
        {
            UsuarioNuevoImplement UsuarioNuevoImpl = new();
            UsuarioNuevoService UsuarioNuevoServicio = new(UsuarioNuevoImpl.GetClientesNuevos());

            List<UsuarioNuevo> ListaClienteNuevos = UsuarioNuevoServicio.ConsultaClientesNuevos();
            // Son 5 ClienteNuevos
            var resultEsperado = 5;

            Assert.IsNotNull(ListaClienteNuevos);
            Assert.AreEqual(resultEsperado, ListaClienteNuevos.Count);
        }

        [Test]
        public void ConsultarClientesNuevosFecha()
        {
            UsuarioNuevoImplement UsuarioNuevoImpl = new();
            UsuarioNuevoService UsuarioNuevoServicio = new(UsuarioNuevoImpl.GetClientesNuevos());

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 4, 10);
            var FechaMax = new DateTime(2022, 4, 30);

            List<UsuarioNuevo> ListaClienteNuevosFecha = UsuarioNuevoServicio.ConsultaClientesNuevosFecha(FechaMin, FechaMax);
            // Son 5 ClienteNuevos
            var resultEsperado = 2;

            Assert.IsNotNull(ListaClienteNuevosFecha);
            Assert.AreEqual(resultEsperado, ListaClienteNuevosFecha.Count);
        }
    }
}
