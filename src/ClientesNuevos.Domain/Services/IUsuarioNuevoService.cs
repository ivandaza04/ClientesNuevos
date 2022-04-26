using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    interface IUsuarioNuevoService
    {
        public List<UsuarioNuevo> ConsultaClientesNuevos();

        public Boolean UsuariosNuevosAResgistrar(List<UsuarioNuevo> clientesNuevos, UsuarioNuevo usuarioNuevos);
    }
}
