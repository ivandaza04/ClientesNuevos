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
        public void GetUsuarioNuevo_ReturnFacturas()
        {
            // Crear objetos para agregar a UsuarioNuevo
            var UsuarioNuevo = GetTestListaClientesNuevos();
            var Servicio = new UsuarioNuevoService(UsuarioNuevo);

            // Agrega Todos los registros
            var result = Servicio.ConsultaClientesNuevos();

            Assert.IsNotNull(UsuarioNuevo.Count);
            Assert.AreEqual(UsuarioNuevo.Count, result.Count);
        }

        [Test]
        public void UsuariosNuevosAResgistrar_ReturnFalse()
        {
            // Crear objetos para agregar a UsuarioNuevo
            var clientesNuevos = GetTestListaClientesNuevos();
            var Servicio = new UsuarioNuevoService(clientesNuevos);
            // Usuario A Registrar
            var testUsuarioNuevo = new UsuarioNuevo
            {
                _id = "2",
                IdAbogado = "2",
                CodigoFactura = "Demo2",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };

            // Evaluar si el usuario a registrar esta en clientesNuevos
            var result = Servicio.UsuariosNuevosAResgistrar(clientesNuevos, testUsuarioNuevo);

            Assert.IsNotNull(testUsuarioNuevo);
            Assert.IsNotNull(clientesNuevos.Count);
            Assert.IsFalse(result);
        }

        [Test]
        public void UsuariosNuevosAResgistrar_ReturnTrue()
        {
            // Crear objetos para agregar a UsuarioNuevo
            var clientesNuevos = GetTestListaClientesNuevos();
            var Servicio = new UsuarioNuevoService(clientesNuevos);
            var testUsuarioNuevo = new UsuarioNuevo();
            // Usuario A No Registrar
            var UsuarioNoNuevo = GetClientesNuevo1();

            // Evaluar si el usuario a registrar esta en clientesNuevos
            var result = Servicio.UsuariosNuevosAResgistrar(clientesNuevos, UsuarioNoNuevo);

            Assert.IsNotNull(testUsuarioNuevo);
            Assert.IsNotNull(clientesNuevos.Count);
            Assert.IsTrue(result);
        }

        private List<UsuarioNuevo> GetTestListaClientesNuevos()
        {
            var testClientesNuevos = new List<UsuarioNuevo>();
            testClientesNuevos.Add(GetClientesNuevo1());
            return testClientesNuevos;
        }

        private UsuarioNuevo GetClientesNuevo1()
        {
            var testClienteNuevo = new UsuarioNuevo
            {
                _id = "1",
                IdAbogado = "1",
                CodigoFactura = "Demo1",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };
            return testClienteNuevo;
        }
    }
}
