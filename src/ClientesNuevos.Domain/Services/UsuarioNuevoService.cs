using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class UsuarioNuevoService : IUsuarioNuevoService
    {
        List<UsuarioNuevo> Usuario_A_Registrar = new List<UsuarioNuevo>();
        List<UsuarioNuevo> UsuariosNuevos = new List<UsuarioNuevo>();

        public UsuarioNuevoService(List<UsuarioNuevo> usuariosNuevos)
        {
            UsuariosNuevos = usuariosNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevos()
        {
            return UsuariosNuevos;
        }

        public Boolean UsuariosNuevosAResgistrar(List<UsuarioNuevo> clientesNuevos, UsuarioNuevo usuarioNuevo)
        {
            // Evaluar si el usuario a registrar esta en clientesNuevos
            foreach (UsuarioNuevo iteracion in clientesNuevos)
                if (usuarioNuevo == iteracion)
                {
                    return true;
                }
            
            return false;
        }
    }
}
