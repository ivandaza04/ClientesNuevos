using ClientesNuevos.Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Test
{
    class RangoFechaTestService
    {
        [Test]
        public void FacturaRangoFecha_ReturnTrue()
        {
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);
            RangoFechaService rangoFecha = new RangoFechaService(FechaMin, FechaMax);

            // Fecha de Factura en el rango
            var FechaCreacionRangoTrue = new DateTime(2022, 4, 20);

            // Evalua condicion de Fecha de Factura en el rango
            bool resultTrue = rangoFecha.ValidarRangoFecha(FechaCreacionRangoTrue);

            // Resultado condicion de Fecha de Factura en el rango
            Assert.IsTrue(resultTrue);
        }

        [Test]
        public void FacturaRangoFecha_ReturnFalse()
        {
            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);
            RangoFechaService rangoFecha = new RangoFechaService(FechaMin, FechaMax);

            // Fecha de Factura en el rango
            var FechaCreacionRangoFalse = new DateTime(2022, 2, 25);

            // Evalua condicion de Fecha de Factura en el rango
            bool resultFalse = rangoFecha.ValidarRangoFecha(FechaCreacionRangoFalse);

            // Resultado condicion de Fecha de Factura fuera del rango
            Assert.IsFalse(resultFalse);
        }
    }
}
