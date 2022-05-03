using ClientesNuevos.Domain.Models;
using ClientesNuevos.Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Test
{
    public class UsuarioNuevoServiceTest
    {
        [Test]
        public void GetClientesNuevos_ReturnClientesNuevos()
        {
            List<UsuarioNuevo> ListaClientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(ListaClientesNuevos);

            // Todos los registros de ClientesNuevos
            List<UsuarioNuevo> result = Servicio.ConsultaClientesNuevos();

            Assert.IsNotNull(ListaClientesNuevos.Count);
            Assert.AreEqual(ListaClientesNuevos.Count, result.Count);
        }

        [Test]
        public void GetClientesNuevosPorFecha_ReturnClientesNuevosEnFecha()
        {
            List<UsuarioNuevo> ListaClientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(ListaClientesNuevos);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            // Todos los registros de ClientesNuevos en las fechas establecidas 
            List<UsuarioNuevo> ListaClientNuevoFecha = Servicio.ConsultaClientesNuevosFecha(FechaMin, FechaMax);
            // resultEsperado es 1 ClientesNuevos en las fecha
            var resultEsperado = 1;

            Assert.IsNotNull(ListaClientNuevoFecha.Count);
            Assert.AreEqual(resultEsperado, ListaClientNuevoFecha.Count);
        }

        [Test]
        public void ClienteRangoFecha_ReturnTrue()
        {
            List<UsuarioNuevo> ListaClientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(ListaClientesNuevos);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            // Fecha de Factura en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 4, 20);

            // Evalua condicion de Fecha de Factura en el rango
            bool resultTrue = Servicio.ClienteNuevoRangoFecha(FechaCreacionRangoTrue, FechaMin, FechaMax);

            // Resultado condicion de Fecha de Factura en el rango
            Assert.IsTrue(resultTrue);
        }

        [Test]
        public void ClienteRangoFecha_ReturnFalse()
        {
            List<UsuarioNuevo> ListaClientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(ListaClientesNuevos);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Fecha de Factura fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            // Evalua condicion de Fecha de Factura fuera del rango
            bool resultFalse = Servicio.ClienteNuevoRangoFecha(FechaCreacionRangoFalse, FechaMin, FechaMax);

            // Resultado condicion de Fecha de Factura fuera del rango
            Assert.IsFalse(resultFalse);
        }

        private List<UsuarioNuevo> GetTestListaClientesNuevos()
        {
            List<UsuarioNuevo> testClientesNuevos = new()
            {
                GetClientesNuevo1()
            };
            return testClientesNuevos;
        }

        private UsuarioNuevo GetClientesNuevo1()
        {
            UsuarioNuevo testClienteNuevo = new()
            {
                _id = "1",
                IdAbogado = "1",
                CodigoFactura = "Demo1",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };
            return testClienteNuevo;
        }

        private List<UsuarioNuevo> GetTestListaUsuariosNuevos()
        {
            List<UsuarioNuevo> testUsuariosNuevos = new()
            {
                GetUsuarioNuevo1(),
                GetUsuarioNuevo2()
            };
            return testUsuariosNuevos;
        }

        private UsuarioNuevo GetUsuarioNuevo1()
        {
            UsuarioNuevo testUsuarioNuevo = new()
            {
                _id = "1",
                IdAbogado = "1",
                CodigoFactura = "Demo1",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };
            return testUsuarioNuevo;
        }

        private UsuarioNuevo GetUsuarioNuevo2()
        {
            UsuarioNuevo testUsuarioNuevo = new()
            {
                _id = "2",
                IdAbogado = "2",
                CodigoFactura = "Demo2",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 22),
            };
            return testUsuarioNuevo;
        }
    }
}
