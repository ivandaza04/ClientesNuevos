using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    interface IAbogadoService
    {
        public List<Abogado> ConsultaAbogados();

        public Abogado ConsultaAbogado(String IdAbogado);
    }
}
