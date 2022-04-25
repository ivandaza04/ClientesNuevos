using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class UsuarioNuevoImplement
    {
        private readonly IMongoCollection<UsuarioNuevo> _UsuarioNuevo;
        private List<UsuarioNuevo> Usuarios;
        private UsuarioNuevo Usuario;

        public UsuarioNuevoImplement()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SGP");

            _UsuarioNuevo = database.GetCollection<UsuarioNuevo>("ClientesNuevos");

            Usuarios = new List<UsuarioNuevo>();

            Usuario = new UsuarioNuevo();
        }

        public UsuarioNuevo CreateUsuarioNuevo(UsuarioNuevo usuario)
        {
            _UsuarioNuevo.InsertOne(usuario);
            return usuario;
        }
    }
}
