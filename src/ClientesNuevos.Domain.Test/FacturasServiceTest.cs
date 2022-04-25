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
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Agrega Todas las facturas
            var result = Servicio.ConsultaFacturas();

            Assert.IsNotNull(Facturas.Count);
            Assert.AreEqual(Facturas.Count, result.Count);
        }

        [Test]
        public void FacturaRangoFecha_ReturnBoolean()
        {
            // Crear objetos para agregar a ListaFacturas
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Fecha de Factura en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 3, 25);
            // Fecha de Factura fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            // Evalua condicion de Fecha de Factura en el rango
            var resultTrue = Servicio.FacturaRangoFecha(FechaCreacionRangoTrue, FechaMin, FechaMax);
            // Evalua condicion de Fecha de Factura fuera del rango
            var resultFalse = Servicio.FacturaRangoFecha(FechaCreacionRangoFalse, FechaMin, FechaMax);

            Assert.IsNotNull(Facturas.Count);
            // Resultado condicion de Fecha de Factura en el rango
            Assert.IsTrue(resultTrue);
            // Resultado condicion de Fecha de Factura fuera del rango
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnIdAbogadosFacturasFecha()
        {
            // Crear objetos para agregar a ListaFacturas
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Agrega Facturas que esta en las fechas establecidas 
            var result = Servicio.ConsultaFacturasFecha(FechaMin, FechaMax);

            Assert.IsNotNull(Facturas.Count);
            Assert.IsNotNull(result.Count);
        }

        [Test]
        public void ConsultaUsuarioNuevo_ReturnListaIdAbogadosNuevos()
        {
            // Crear objetos para agregar a ListaFacturas
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Evalua Factura esta en las fechas establecidas 
            var ListaIdAbogados = Servicio.ConsultaFacturasFecha(FechaMin, FechaMax);

            // Agrega Facturas con Usuarios Nuevos
            var result = Servicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaIdAbogados,FechaMax);
            // Facturas Agregadas en la fecha con un usuario Nuevo
            var resultEsperado = 1;

            Assert.IsNotNull(Facturas.Count);
            Assert.IsNotNull(ListaIdAbogados.Count);
            Assert.IsNotNull(result.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        [Test]
        public void ContarIdAbogado_ReturnNIdAbogados()
        {
            // Crear objetos para agregar a ListaFacturas
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            var FechaMax = new DateTime(2022, 4, 25);
            var IdAbogado = "1";

            //  Evalua IdAbogado tiene Facturas anteriores
            var result = Servicio.ContarIdAbogado(IdAbogado, FechaMax);
            // Numero de Facturas con el mismo IdAbogado
            var resultEsperado = 2;

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result);

        }

        private List<Factura> GetTestListaFacturas()
        {
            var testFacturas = new List<Factura>();
            testFacturas.Add(GetTestFactura1());
            testFacturas.Add(GetTestFactura2());
            testFacturas.Add(GetTestFactura3());
            testFacturas.Add(GetTestFactura4());
            return testFacturas;
        }

        private Factura GetTestFactura1()
        {
            var testFactura = new Factura
            {
                _id = "1",
                Codigo = "Demo1",
                IdAbogado = "1",
                Estado = "test",
                Pagado = false,
                FechaUltimaComunicacion = DateTime.Now,
                FechaCreacion = new DateTime(2022, 4, 20),
                InicioFactura = DateTime.Now,
                FinFactura = DateTime.Now,
                PathPdf = "test",
                SubTotal = "test",
                RetencionEnFuente = "",
                Iva = "",
                Total = "test",
                Token = "test",
                TransactionId = "test",
                TransactionCode = "test",
                TransactionMessage = "test",
                FechaTransaccion = DateTime.Now,
                DescuentoVolumen = false,
                DescuentoAntiguedad = false,
            };

            return testFactura;
        }

        private Factura GetTestFactura2()
        {
            var testFactura = new Factura
            {
                _id = "2",
                Codigo = "Demo1",
                IdAbogado = "2",
                Estado = "test",
                Pagado = false,
                FechaUltimaComunicacion = DateTime.Now,
                FechaCreacion = new DateTime(2022, 3, 20),
                InicioFactura = DateTime.Now,
                FinFactura = DateTime.Now,
                PathPdf = "test",
                SubTotal = "test",
                RetencionEnFuente = "",
                Iva = "",
                Total = "test",
                Token = "test",
                TransactionId = "test",
                TransactionCode = "test",
                TransactionMessage = "test",
                FechaTransaccion = DateTime.Now,
                DescuentoVolumen = false,
                DescuentoAntiguedad = false,
            };

            return testFactura;
        }

        private Factura GetTestFactura3()
        {
            var testFactura = new Factura
            {
                _id = "3",
                Codigo = "Demo3",
                IdAbogado = "1",
                Estado = "test",
                Pagado = false,
                FechaUltimaComunicacion = DateTime.Now,
                FechaCreacion = new DateTime(2022, 4, 20),
                InicioFactura = DateTime.Now,
                FinFactura = DateTime.Now,
                PathPdf = "test",
                SubTotal = "test",
                RetencionEnFuente = "",
                Iva = "",
                Total = "test",
                Token = "test",
                TransactionId = "test",
                TransactionCode = "test",
                TransactionMessage = "test",
                FechaTransaccion = DateTime.Now,
                DescuentoVolumen = false,
                DescuentoAntiguedad = false,
            };

            return testFactura;
        }

        private Factura GetTestFactura4()
        {
            var testFactura = new Factura
            {
                _id = "4",
                Codigo = "Demo4",
                IdAbogado = "3",
                Estado = "test",
                Pagado = false,
                FechaUltimaComunicacion = DateTime.Now,
                FechaCreacion = new DateTime(2022, 4, 20),
                InicioFactura = DateTime.Now,
                FinFactura = DateTime.Now,
                PathPdf = "test",
                SubTotal = "test",
                RetencionEnFuente = "",
                Iva = "",
                Total = "test",
                Token = "test",
                TransactionId = "test",
                TransactionCode = "test",
                TransactionMessage = "test",
                FechaTransaccion = DateTime.Now,
                DescuentoVolumen = false,
                DescuentoAntiguedad = false,
            };

            return testFactura;
        }
    }
}
