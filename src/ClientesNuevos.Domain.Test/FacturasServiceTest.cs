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
    public class FacturasServiceTest
    {

        [Test]
        public void GetFacturas_ReturnFacturas()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new(ListaFacturas);

            // Agrega Todas las facturas
            List<Factura> result = Servicio.ConsultaFacturas();

            var numerodefacturas = 4;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.AreEqual(numerodefacturas, result.Count);
        }

        [Test]
        public void FacturaRangoFecha_ReturnTrue()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new(ListaFacturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            // Fecha de Factura en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 4, 20);

            // Evalua condicion de Fecha de Factura en el rango
            bool resultTrue = Servicio.FacturaRangoFecha(FechaCreacionRangoTrue, FechaMin, FechaMax);

            Assert.IsNotNull(ListaFacturas.Count);
            // Resultado condicion de Fecha de Factura en el rango
            Assert.IsTrue(resultTrue);
        }

        [Test]
        public void FacturaRangoFecha_ReturnFalse()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new(ListaFacturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Fecha de Factura fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            // Evalua condicion de Fecha de Factura fuera del rango
            bool resultFalse = Servicio.FacturaRangoFecha(FechaCreacionRangoFalse, FechaMin, FechaMax);

            Assert.IsNotNull(ListaFacturas.Count);
            // Resultado condicion de Fecha de Factura fuera del rango
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnFacturasFecha()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new(ListaFacturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Agrega Facturas que esta en las fechas establecidas 
            List<Factura> result = Servicio.ConsultaFacturasFecha(FechaMin, FechaMax);
            // resultEsperado es 3 facturas dentro del rango
            var resultEsperado = 3;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.IsNotNull(result.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        [Test]
        public void ConsultaUsuarioNuevo_ReturnUsuarioNuevos()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new(ListaFacturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Evalua Factura esta en las fechas establecidas 
            List<Factura> ListaIdAbogados = Servicio.ConsultaFacturasFecha(FechaMin, FechaMax);

            // Agrega Usuarios Nuevos
            List<UsuarioNuevo> result = Servicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaIdAbogados,FechaMax);
            // Agrega 2 Usuarios Nuevos, ya que IdAbogado 1 y 2 son nuevos
            // Ya que abogado IdAbogado = "3" no es nuevo
            var resultEsperado = 2;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.IsNotNull(ListaIdAbogados.Count);
            Assert.IsNotNull(result.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        [Test]
        public void ContarIdAbogado_ReturnIgualA1()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new FacturaService(ListaFacturas);

            var FechaMax = new DateTime(2022, 4, 25);
            var IdAbogado = "1";

            //  Evalua IdAbogado tiene Facturas anteriores
            int result = Servicio.ContarIdAbogado(IdAbogado, FechaMax);
            // Numero de Facturas con el mismo IdAbogado = 1
            var resultEsperado = 1;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);
        }

        [Test]
        public void ContarIdAbogado_ReturnMayorA1()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetTestListaFacturas();
            FacturaService Servicio = new FacturaService(ListaFacturas);

            var FechaMax = new DateTime(2022, 4, 25);
            var IdAbogado = "3";

            //  Evalua IdAbogado tiene Facturas anteriores
            int result = Servicio.ContarIdAbogado(IdAbogado, FechaMax);
            // Numero de Facturas con el mismo IdAbogado = 1
            var resultEsperado = 2;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);
        }

        private List<Factura> GetTestListaFacturas()
        {
            List<Factura> testFacturas = new List<Factura>
            {
                GetTestFactura1(),
                GetTestFactura2(),
                GetTestFactura3(),
                GetTestFactura4()
            };
            return testFacturas;
        }

        private Factura GetTestFactura1()
        {
            Factura testFactura = new()
            {
                _id = "1",
                Codigo = "Demo1",
                IdAbogado = "1",
                FechaCreacion = new DateTime(2022, 4, 5),
                SubTotal = "test"
            };

            return testFactura;
        }

        private Factura GetTestFactura2()
        {
            Factura testFactura = new()
            {
                _id = "2",
                Codigo = "Demo1",
                IdAbogado = "2",
                FechaCreacion = new DateTime(2022, 4, 10),
                SubTotal = "test"
            };

            return testFactura;
        }

        private Factura GetTestFactura3()
        {
            Factura testFactura = new()
            {
                _id = "3",
                Codigo = "Demo3",
                IdAbogado = "3",
                FechaCreacion = new DateTime(2022, 4, 20),
                SubTotal = "test"
            };

            return testFactura;
        }

        private Factura GetTestFactura4()
        {
            Factura testFactura = new()
            {
                _id = "4",
                Codigo = "Demo4",
                IdAbogado = "3",
                FechaCreacion = new DateTime(2022, 3, 16),
                SubTotal = "test"
            };

            return testFactura;
        }

    }
}
