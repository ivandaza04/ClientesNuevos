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
        List<Abogado> Abogados = new List<Abogado>();
        Abogado InfoAbogados = new Abogado();

        public AbogadoService(List<Abogado> abogados)
        {
            Abogados = abogados;
        }

        public List<Abogado> ConsultaAbogados()
        {
            return Abogados;
        }

        public Abogado ConsultaInfoAbogados(String IdAbogado)
        {
            // Buscar informacion abogado por el IdAbogado
            foreach (Abogado iteracion in Abogados)
            {
                if (iteracion._id == IdAbogado)
                    InfoAbogados = iteracion;
                else
                    InfoAbogados = null;
            }
            return InfoAbogados;
        }
    }
}
