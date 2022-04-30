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
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);
            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            // Agrega Todas las facturas
            List<Factura> result = facturaService.ConsultaFacturas();

            var numerodefacturas = 3;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.AreEqual(numerodefacturas, result.Count);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnFacturasFecha()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            DateTime FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            // Agrega Facturas que esta en las fechas establecidas 
            List<Factura> result = facturaService.AgregaFacturasFecha();
            // resultEsperado es 2 facturas dentro del rango
            var resultEsperado = 2;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.IsNotNull(result.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        [Test]
        public void FacturaRangoFecha_ReturnTrue()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            // Fecha de Factura en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 4, 20);

            // Evalua condicion de Fecha de Factura en el rango
            bool resultTrue = facturaService.FacturaRangoFecha(FechaCreacionRangoTrue);

            // Resultado condicion de Fecha de Factura en el rango
            Assert.IsTrue(resultTrue);
        }

        [Test]
        public void FacturaRangoFecha_ReturnFalse()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            // Fecha de Factura fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            // Evalua condicion de Fecha de Factura fuera del rango
            bool resultFalse = facturaService.FacturaRangoFecha(FechaCreacionRangoFalse);

            // Resultado condicion de Fecha de Factura fuera del rango
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public void AgregarUsuarioNuevo_ReturnUsuarioNuevos()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            // Evalua Factura esta en las fechas establecidas 
            List<Factura> ListaFacturasFecha = facturaService.AgregaFacturasFecha();

            // Agrega Usuarios Nuevos
            List<UsuarioNuevo> result = facturaService.AgregarIdAbogadoEsUsuarioNuevo(ListaFacturasFecha);
            // Agrega 1 Usuarios Nuevos, ya que IdAbogado 2 es nuevos
            var resultEsperado = 1;

            Assert.IsNotNull(ListaFacturas.Count);
            Assert.IsNotNull(ListaFacturasFecha.Count);
            Assert.IsNotNull(result.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        [Test]
        public void ContarIdAbogado_ReturnIgualA1()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            DateTime FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            var IdAbogado = "2";

            //  Evalua IdAbogado tiene Facturas anteriores
            int result = facturaService.ContarIdAbogado(IdAbogado);
            // Numero de Facturas con el mismo IdAbogado = 2 es 1
            var resultEsperado = 1;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);
        }

        [Test]
        public void ContarIdAbogado_ReturnMayorA1()
        {
            // Crear objetos para agregar a ListaFacturas
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            DateTime FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas, FechaMin, FechaMax);

            var IdAbogado = "1";

            //  Evalua IdAbogado tiene Facturas anteriores
            int result = facturaService.ContarIdAbogado(IdAbogado);
            // Numero de Facturas con el mismo IdAbogado = 1 son 2
            var resultEsperado = 2;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);
        }

        [Test]
        public void Contardor_ReturnNumeroVecesIdAbogados()
        {
            List<Factura> ListaFacturas = GetListaFacturasTest();
            var FechaMin = new DateTime(2022, 4, 1);
            DateTime FechaMax = new DateTime(2022, 4, 30);

            FacturaService facturaService = new FacturaService(ListaFacturas,FechaMin, FechaMax);

            var FechaCreacion = new DateTime(2022, 4, 10);

            var NumeroIdAbogados = 0;

            int result = facturaService.Contador(FechaCreacion, NumeroIdAbogados);
            // NumeroIdAbogados aumenta a uno ya que la FechaCreacion es menor a FechaMax
            var resultEsperado = 1;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);
        }

        private List<Factura> GetListaFacturasTest()
        {
            List<Factura> facturasTest = new List<Factura>();
            facturasTest.Add(GetFacturaTest1());
            facturasTest.Add(GetFacturaTest2());
            facturasTest.Add(GetFacturaTest3());
            return facturasTest;
        }

        private Factura GetFacturaTest1()
        {
            Factura facturaTest = new Factura("1", "Demo1", "1", new DateTime(2022, 4, 5), "test");
            return facturaTest;
        }

        private Factura GetFacturaTest2()
        {
            Factura facturaTest = new Factura("2", "Demo2", "1", new DateTime(2022, 3, 5), "test");
            return facturaTest;
        }

        private Factura GetFacturaTest3()
        {
            Factura facturaTest = new Factura("3", "Demo3", "2", new DateTime(2022, 4, 10), "test");
            return facturaTest;
        }

    }
}
