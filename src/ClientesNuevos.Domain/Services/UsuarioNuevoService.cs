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
        List<UsuarioNuevo> UsuarioRegistrar = new List<UsuarioNuevo>();
        List<UsuarioNuevo> ClientesNuevos = new List<UsuarioNuevo>();

        public UsuarioNuevoService(List<UsuarioNuevo> clientesNuevos)
        {
            ClientesNuevos = clientesNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevos()
        {
            return ClientesNuevos;
        }

        public List<UsuarioNuevo> UsuariosNuevosRegistrar(List<UsuarioNuevo> usuariosNuevos)
        {
            foreach (UsuarioNuevo usuario in usuariosNuevos)
                if (UsuariosNuevosARegistrar(usuario) != true)
                    UsuarioRegistrar.Add(usuario);

            return UsuarioRegistrar;
        }

        public Boolean UsuariosNuevosARegistrar(UsuarioNuevo usuarioNuevo)
        {
            // Evaluar si el usuario a registrar esta en clientesNuevos
            foreach (UsuarioNuevo cliente in ClientesNuevos)
                if (usuarioNuevo.IdAbogado == cliente.IdAbogado)
                {
                    return true;
                }
            
            return false;
        }
    }
}
