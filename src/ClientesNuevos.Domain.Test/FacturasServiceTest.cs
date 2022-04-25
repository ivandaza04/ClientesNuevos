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
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            // Fecha en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 3, 25);
            // Fecha en fuera del rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            var resultTrue = Servicio.FacturaRangoFecha(FechaCreacionRangoTrue, FechaMin, FechaMax);
            var resultFalse = Servicio.FacturaRangoFecha(FechaCreacionRangoFalse, FechaMin, FechaMax);

            Assert.IsNotNull(Facturas.Count);
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnIdAbogadosFacturasFecha()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);

            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);

            var result = Servicio.ConsultaIdAbogados_FacturasFecha(FechaMin, FechaMax);

            Assert.IsNotNull(Facturas.Count);
            Assert.IsNotNull(result.Count);
        }

        [Test]
        public void ConsultaUsuarioNuevo_ReturnListaIdAbogadosNuevos()
        {
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);
            // Rango de Fechas
            var FechaMin = new DateTime(2022, 3, 25);
            var FechaMax = new DateTime(2022, 4, 25);
            // Consulta Facturas en la Fecha
            var ListaIdAbogados = Servicio.ConsultaIdAbogados_FacturasFecha(FechaMin, FechaMax);

            var result = Servicio.ConsultaIdAbogados_FacturasFecha(ListaIdAbogados,FechaMax);
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
            var Facturas = GetTestListaFacturas();
            var Servicio = new FacturaService(Facturas);
            var FechaMax = new DateTime(2022, 4, 25);
            var IdAbogado = "1";

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
