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
    public class AbogadoImplTest
    {
        [Test]
        public void CreateAbogado_ReturnAbogado()
        {
            SettingsDatabase settingsDatabase = new();
            AbogadoImplement AbogadoImpl = new(settingsDatabase);
            AbogadoService AbogadoServicio = new(AbogadoImpl.GetAbogados());

            // Crea fecturas en la collecion
            foreach (Abogado abogado in GetTestListaAbogados())
                AbogadoImpl.CreateAbogado(abogado);

            List<Abogado> ListaAbogado = AbogadoServicio.ConsultaAbogados();

            Assert.IsNotNull(ListaAbogado);
        }

        private List<Abogado> GetTestListaAbogados()
        {
            List<Abogado> testAbogados = new()
            {
                GetTestAbogado1(),
                GetTestAbogado2(),
                GetTestAbogado3(),
                GetTestAbogado4(),
                GetTestAbogado5(),
            };
            return testAbogados;
        }

        private Abogado GetTestAbogado1()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "11",
                Email = "william6071@hotmail.com",
                Activo = true,
                Nombre = "William Sánchez",
                Ciudad = "Tunja"
            };
            return GetTestAbogado1();
        }

        private Abogado GetTestAbogado2()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "12",
                Email = "alvape71@hotmail.com",
                Activo = true,
                Nombre = "Alvaro Perez",
                Ciudad = "Tunja"
            };
            return GetTestAbogado2();
        }

        private Abogado GetTestAbogado3()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "24",
                Email = "jolo15@hotmail.com",
                Activo = true,
                Nombre = "Jose Lopez",
                Ciudad = "Tunja"
            };
            return GetTestAbogado3();
        }

        private Abogado GetTestAbogado4()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "22",
                Email = "micorreo5@hotmail.com",
                Activo = true,
                Nombre = "Pedro Lopez",
                Ciudad = "Tunja"
            };
            return GetTestAbogado4();
        }

        private Abogado GetTestAbogado5()
        {
            Abogado testAbogado = new Abogado
            {
                _id = "26",
                Email = "ana26@hotmail.com",
                Activo = true,
                Nombre = "Ana Gomez",
                Ciudad = "Tunja"
            };
            return GetTestAbogado5();
        }
    }
}
