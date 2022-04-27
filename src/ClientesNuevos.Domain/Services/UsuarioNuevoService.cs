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
        List<UsuarioNuevo> ListaUsuarioRegistrar = new List<UsuarioNuevo>();
        List<UsuarioNuevo> ListaClientesNuevos = new List<UsuarioNuevo>();

        public UsuarioNuevoService(List<UsuarioNuevo> listaClientesNuevos)
        {
            ListaClientesNuevos = listaClientesNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevos()
        {
            return ListaClientesNuevos;
        }

        // Valora si usuario de UsuariosNuevos esta en ListaClientesNuevos y lo agrega en ListaUsuarioRegistrar
        public List<UsuarioNuevo> UsuariosNuevosRegistrar(List<UsuarioNuevo> usuariosNuevos)
        {
            foreach (UsuarioNuevo usuario in usuariosNuevos)
                if (UsuariosNuevosARegistrar(usuario) != true)
                    ListaUsuarioRegistrar.Add(usuario);

            return ListaUsuarioRegistrar;
        }

        // Evaluar si el usuario a registrar esta en clientesNuevos
        public Boolean UsuariosNuevosARegistrar(UsuarioNuevo usuarioNuevo)
        {
            foreach (UsuarioNuevo cliente in ListaClientesNuevos)
                if (usuarioNuevo.IdAbogado == cliente.IdAbogado)
                {
                    return true;
                }
            
            return false;
        }
    }
}
