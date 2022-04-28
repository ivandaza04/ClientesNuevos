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
        private List<UsuarioNuevo> ListaClientesNuevos;
        private UsuarioNuevo Usuario;

        public UsuarioNuevoImplement(SettingsDatabase clienteNuevoDatabase)
        {
            var client = new MongoClient(clienteNuevoDatabase.ConnectionString);
            var database = client.GetDatabase(clienteNuevoDatabase.SGPDatabaseName);

            _UsuarioNuevo = database.GetCollection<UsuarioNuevo>(clienteNuevoDatabase.ClientesNuevosCollectionName);

            ListaClientesNuevos = new List<UsuarioNuevo>();

            Usuario = new UsuarioNuevo();
        }

        public List<UsuarioNuevo> GetClientesNuevos()
        {
            var Query = _UsuarioNuevo.Find(UsuarioNuevo => true).ToList();
            foreach (UsuarioNuevo result in Query)
                ListaClientesNuevos.Add(new UsuarioNuevo(result._id, result.IdAbogado, result.CodigoFactura, result.SubTotalFactura, result.FechaCreacionFactura));
            return ListaClientesNuevos;
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
