using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class AbogadoService : IAbogadoService
    {
        List<Abogado> ListaAbogados = new List<Abogado>();
        Abogado Abogado = new Abogado();

        public AbogadoService(List<Abogado> listaAbogados)
        {
            ListaAbogados = listaAbogados;
        }

        public List<Abogado> ConsultaAbogados()
        {
            return ListaAbogados;
        }

        // Consultar abogado en ListaAbogados y devolver objeto Abogado
        public Abogado ConsultaAbogado(String idAbogado)
        {
            // Buscar informacion abogado por el IdAbogado
            foreach (Abogado abogado in ListaAbogados)
            {
                if (abogado._id == idAbogado)
                    Abogado = abogado;
                else
                    Abogado = null;
            }
            return Abogado;
        }
    }
}
