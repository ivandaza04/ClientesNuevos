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
            List<UsuarioNuevo> UsuarioNuevo = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(UsuarioNuevo);

            // Agrega Todos los registros
            List<UsuarioNuevo> result = Servicio.ConsultaClientesNuevos();

            Assert.IsNotNull(UsuarioNuevo.Count);
            Assert.AreEqual(UsuarioNuevo.Count, result.Count);
        }

        [Test]
        public void UsuariosNuevosARegistrar_ReturnFalse()
        {
            // Crear objetos para agregar a UsuarioNuevo
            List<UsuarioNuevo> clientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(clientesNuevos);
            // Usuario A Registrar
            UsuarioNuevo testUsuarioNuevo = new()
            {
                _id = "2",
                IdAbogado = "2",
                CodigoFactura = "Demo2",
                SubTotalFactura = "test",
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };

            // Evaluar si el usuario a registrar esta en clientesNuevos
            bool result = Servicio.UsuariosNuevosARegistrar(testUsuarioNuevo);

            Assert.IsNotNull(testUsuarioNuevo);
            Assert.IsNotNull(clientesNuevos.Count);
            Assert.IsFalse(result);
        }

        [Test]
        public void UsuariosNuevosARegistrar_ReturnTrue()
        {
            // Crear objetos para agregar a UsuarioNuevo
            List<UsuarioNuevo> clientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(clientesNuevos);
            UsuarioNuevo testUsuarioNuevo = new();
            // Usuario A No Registrar
            UsuarioNuevo testUsuarioNoNuevo = GetClientesNuevo1();

            // Evaluar si el usuario a registrar esta en clientesNuevos
            bool result = Servicio.UsuariosNuevosARegistrar(testUsuarioNoNuevo);

            Assert.IsNotNull(testUsuarioNuevo);
            Assert.IsNotNull(clientesNuevos.Count);
            Assert.IsTrue(result);
        }

        [Test]
        public void UsuariosNuevosARegistrar_ReturnListaUsuarioNuevos()
        {
            // Crear objetos para agregar a UsuarioNuevo
            List<UsuarioNuevo> clientesNuevos = GetTestListaClientesNuevos();
            UsuarioNuevoService Servicio = new(clientesNuevos);

            List<UsuarioNuevo> usuariosNuevos = GetTestListaUsuariosNuevos();


            List<UsuarioNuevo> result = Servicio.UsuariosNuevosRegistrar(usuariosNuevos);
            // Se espera un solo un usuario para registrar
            var resultEsperado = 1;

            Assert.IsNotNull(clientesNuevos.Count);
            Assert.IsNotNull(usuariosNuevos.Count);
            Assert.AreEqual(resultEsperado, result.Count);
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
                FechaCreacionFactura = new DateTime(2022, 4, 20),
            };
            return testUsuarioNuevo;
        }
    }
}
