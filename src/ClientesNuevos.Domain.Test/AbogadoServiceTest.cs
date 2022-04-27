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
    public class AbogadoServiceTest
    {
        [Test]
        public void GetAbogados_ReturnAbogados()
        {
            // Crear objetos para agregar a ListaAbogados
            List<Abogado> ListaAbogados = GetTestListaAbogados();
            AbogadoService Servicio = new(ListaAbogados);

            // Agrega Todas las Abogados
            List<Abogado> result = Servicio.ConsultaAbogados();

            Assert.IsNotNull(ListaAbogados.Count);
            Assert.AreEqual(ListaAbogados.Count, result.Count);
        }

        [Test]
        public void ConsultaInfoAbogados_ReturnAbogado()
        {
            // Crear objetos para agregar a ListaAbogados
            List<Abogado> ListaAbogados = GetTestListaAbogados();
            AbogadoService Servicio = new(ListaAbogados);
            string IdAbogado = "1042";

            // Agrega Todos los registros
            Abogado result = Servicio.ConsultaAbogado(IdAbogado);
            // Nombre Abogado
            string resultEsperado = "William Sánchez";

            Assert.IsNotNull(result);
            Assert.AreEqual(resultEsperado, result.Nombre);
        }

        private List<Abogado> GetTestListaAbogados()
        {
            List<Abogado> testAbogados = new()
            {
                GetTestAbogado1()
            };
            return testAbogados;
        }

        private Abogado GetTestAbogado1()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "1042",
                Email = "william6071@hotmail.com",
                Activo = true,
                Nombre = "William Sánchez",
                Ciudad = "Tunja"

            };
            return GetTestAbogado1();
        }
    }
}
