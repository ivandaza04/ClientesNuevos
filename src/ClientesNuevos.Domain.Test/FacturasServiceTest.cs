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
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            var result = Servicio.ConsultaFacturas() as List<Factura>;

            Assert.IsNotNull(Facturas.Count);
            Assert.AreEqual(Facturas.Count, result.Count);
        }

        [Test]
        public void FacturaRangoFecha_ReturnBoolean()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var fechaInicio = new DateTime(2022, 3, 25);
            var fechaFinal = new DateTime(2022, 4, 25);

            // Fecha en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 3, 25);
            // Fecha en fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            var resultTrue = Servicio.FacturaRangoFecha(FechaCreacionRangoTrue, fechaInicio, fechaFinal);
            var resultFalse = Servicio.FacturaRangoFecha(FechaCreacionRangoFalse, fechaInicio, fechaFinal);

            Assert.IsNotNull(Facturas.Count);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnFacturasFecha()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var fechaInicio = new DateTime(2022, 3, 25);
            var fechaFinal = new DateTime(2022, 4, 25);

            var result = Servicio.ConsultaFacturasFecha(fechaInicio, fechaFinal);
            var resultEsperado = 1;

            Assert.IsNotNull(Facturas.Count);
            Assert.AreEqual(resultEsperado, result.Count);
        }

        private List<Factura> GetTestListaFacturas()
        {
            var testFacturas = new List<Factura>();
            testFacturas.Add(GetTestFactura1());
            testFacturas.Add(GetTestFactura2());
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
    }
}
