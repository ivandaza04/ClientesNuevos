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
            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var database = client.GetDatabase("SGP");

            _UsuarioNuevo = database.GetCollection<UsuarioNuevo>("ClientesNuevos");

            Usuarios = new List<UsuarioNuevo>();

            Usuario = new UsuarioNuevo();
        }

        public List<UsuarioNuevo> GetClientesNuevos()
        {
            var Query = _UsuarioNuevo.Find(UsuarioNuevo => true).ToList();
            foreach (UsuarioNuevo result in Query)
                Usuarios.Add(new UsuarioNuevo(result._id, result.IdAbogado, result.CodigoFactura, result.SubTotalFactura, result.FechaCreacionFactura));
            return Usuarios;
        }

        public UsuarioNuevo CreateUsuarioNuevo(UsuarioNuevo usuario)
        {
            try
            {
                _UsuarioNuevo.InsertOne(usuario);
            }
            catch (MongoWriteException writeEx) {
                writeEx.ToString();
            }

                return usuario;
        }
    }
}
