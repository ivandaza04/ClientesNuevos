using ClientesNuevos.Domain.Models;
using ClientesNuevos.Domain.Services;
using ClientesNuevos.Implement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteNuevos.Implement.Test
{
    public class FacturaImplTest
    {
        [Test]
        public void CreateFacturas_ReturnFactura()
        {
            FacturaImplement FacturaImpl = new();
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());
            List<Factura> ListaFacturas = new List<Factura>();

            // Crea fecturas en la collecion
            foreach (Factura factura in GetTestListaFacturas())
                FacturaImpl.CreateFactura(factura);

            ListaFacturas = FacturaServicio.ConsultaFacturas();

            Assert.IsNotNull(ListaFacturas);
        }

        [Test]
        public void GetFacturas_ReturnFacturas()
        {
            FacturaImplement FacturaImpl = new();
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());
            List<Factura> ListaFacturas = new List<Factura>();

            ListaFacturas = FacturaServicio.ConsultaFacturas();
            var resultEsperado = 19;

            Assert.IsNotEmpty(ListaFacturas);
            Assert.AreEqual(resultEsperado, ListaFacturas.Count);
        }

        [Test]
        public void ConsultaFacturasFecha_ReturnFacturaFecha()
        {
            FacturaImplement FacturaImpl = new();
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());
            List<Factura> ListaFacturasEnFecha = new List<Factura>();

            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);

            ListaFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);
            // Factura en el mes de Abril
            var resultEsperado = 9;

            Assert.IsNotEmpty(ListaFacturasEnFecha);
            Assert.AreEqual(resultEsperado, ListaFacturasEnFecha.Count);
        }

        [Test]
        public void ConsultaUsuarioNuevo_ReturnUsuarioNuevos()
        {
            FacturaImplement FacturaImpl = new();
            FacturaService FacturaServicio = new(FacturaImpl.GetFacturas());
            List<Factura> ListaFacturasEnFecha = new List<Factura>();
            List<UsuarioNuevo> ListaUsuariosNuevos = new List<UsuarioNuevo>();

            var FechaMin = new DateTime(2022, 4, 1);
            var FechaMax = new DateTime(2022, 4, 30);
            ListaFacturasEnFecha = FacturaServicio.ConsultaFacturasFecha(FechaMin, FechaMax);

            ListaUsuariosNuevos = FacturaServicio.ConsultaIdAbogadoEsUsuarioNuevo(ListaFacturasEnFecha, FechaMax);
            // Factura con usuario nuevos en Abril
            var resultEsperado = 5;

            Assert.IsNotNull(ListaUsuariosNuevos);
            Assert.AreEqual(resultEsperado, ListaUsuariosNuevos.Count);
        }


        private List<Factura> GetTestListaFacturas()
        {
            List<Factura> testFacturas = new List<Factura>
            {
                GetTestFactura11(),
                GetTestFactura12(),
                GetTestFactura13(),
                GetTestFactura14(),
                GetTestFactura15(),
                GetTestFactura16(),
                GetTestFactura17(),
                GetTestFactura18(),
                GetTestFactura19(),
                GetTestFactura20(),
                GetTestFactura21(),
                GetTestFactura22(),
                GetTestFactura23(),
                GetTestFactura24(),
                GetTestFactura25(),
                GetTestFactura26(),
                GetTestFactura27(),
                GetTestFactura28(),
                GetTestFactura29(),
            };
            return testFacturas;
        }

        private Factura GetTestFactura11()
        {
            Factura testFactura = new()
            {
                _id = "11",
                Codigo = "B-111",
                IdAbogado = "11",
                FechaCreacion = new DateTime(2022, 3, 1),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura12()
        {
            Factura testFactura = new()
            {
                _id = "12",
                Codigo = "B-112",
                IdAbogado = "12",
                FechaCreacion = new DateTime(2022, 3, 2),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura13()
        {
            Factura testFactura = new()
            {
                _id = "13",
                Codigo = "B-113",
                IdAbogado = "12",
                FechaCreacion = new DateTime(2022, 3, 5),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura14()
        {
            Factura testFactura = new()
            {
                _id = "14",
                Codigo = "B-114",
                IdAbogado = "14",
                FechaCreacion = new DateTime(2022, 3, 7),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura15()
        {
            Factura testFactura = new()
            {
                _id = "15",
                Codigo = "B-115",
                IdAbogado = "15",
                FechaCreacion = new DateTime(2022, 3, 8),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura16()
        {
            Factura testFactura = new()
            {
                _id = "16",
                Codigo = "B-116",
                IdAbogado = "16",
                FechaCreacion = new DateTime(2022, 3, 11),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura17()
        {
            Factura testFactura = new()
            {
                _id = "17",
                Codigo = "B-117",
                IdAbogado = "17",
                FechaCreacion = new DateTime(2022, 3, 13),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura18()
        {
            Factura testFactura = new()
            {
                _id = "18",
                Codigo = "B-118",
                IdAbogado = "18",
                FechaCreacion = new DateTime(2022, 3, 14),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura19()
        {
            Factura testFactura = new()
            {
                _id = "19",
                Codigo = "B-119",
                IdAbogado = "19",
                FechaCreacion = new DateTime(2022, 3, 17),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura20()
        {
            Factura testFactura = new()
            {
                _id = "20",
                Codigo = "B-120",
                IdAbogado = "20",
                FechaCreacion = new DateTime(2022, 3, 22),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura21()
        {
            Factura testFactura = new()
            {
                _id = "21",
                Codigo = "B-121",
                IdAbogado = "11",
                FechaCreacion = new DateTime(2022, 4, 1),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura22()
        {
            Factura testFactura = new()
            {
                _id = "22",
                Codigo = "B-122",
                IdAbogado = "22",
                FechaCreacion = new DateTime(2022, 4, 2),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura23()
        {
            Factura testFactura = new()
            {
                _id = "23",
                Codigo = "B-123",
                IdAbogado = "13",
                FechaCreacion = new DateTime(2022, 4, 5),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura24()
        {
            Factura testFactura = new()
            {
                _id = "24",
                Codigo = "B-124",
                IdAbogado = "24",
                FechaCreacion = new DateTime(2022, 4, 7),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura25()
        {
            Factura testFactura = new()
            {
                _id = "25",
                Codigo = "B-125",
                IdAbogado = "15",
                FechaCreacion = new DateTime(2022, 4, 8),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura26()
        {
            Factura testFactura = new()
            {
                _id = "26",
                Codigo = "B-126",
                IdAbogado = "26",
                FechaCreacion = new DateTime(2022, 4, 11),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura27()
        {
            Factura testFactura = new()
            {
                _id = "27",
                Codigo = "B-127",
                IdAbogado = "17",
                FechaCreacion = new DateTime(2022, 4, 13),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura28()
        {
            Factura testFactura = new()
            {
                _id = "28",
                Codigo = "B-128",
                IdAbogado = "28",
                FechaCreacion = new DateTime(2022, 4, 14),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }

        private Factura GetTestFactura29()
        {
            Factura testFactura = new()
            {
                _id = "29",
                Codigo = "B-129",
                IdAbogado = "20",
                FechaCreacion = new DateTime(2022, 4, 17),
                SubTotal = "138092.00000"
            };

            return testFactura;
        }
    }
}
