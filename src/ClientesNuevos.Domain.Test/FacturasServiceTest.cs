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
            var Servicio = new FacturasService(Facturas);

            var result = Servicio.ConsultaFacturas() as List<Factura>;

            Assert.IsNotNull(Facturas.Count);
            Assert.AreEqual(Facturas.Count, result.Count);
        }

        [Test]
        public void FacturaRangoFecha_ReturnTrue()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturasService(Facturas);

            var FechaCreacion = new DateTime(2022, 3, 25);
            var fechaInicio = new DateTime(2022, 3, 25);
            var fechaFinal = new DateTime(2022, 4, 25);

            var result = Servicio.FacturaRangoFecha(FechaCreacion, fechaInicio, fechaFinal);

            Assert.IsNotNull(Facturas[0]);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void FacturaRangoFecha_ReturnFalse()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturasService(Facturas);

            var FechaCreacion = new DateTime(2022, 2, 25);
            var fechaInicio = new DateTime(2022, 3, 25);
            var fechaFinal = new DateTime(2022, 4, 25);

            var result = Servicio.FacturaRangoFecha(FechaCreacion, fechaInicio, fechaFinal);

            Assert.IsNotNull(Facturas[0]);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnFacturasFecha()
        {

        }

            private List<Factura> GetTestListaFacturas()
        {
            var testFacturas = new List<Factura>();
            testFacturas.Add(GetTestFactura());

            return testFacturas;
        }

        private Factura GetTestFactura()
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
    }
}
