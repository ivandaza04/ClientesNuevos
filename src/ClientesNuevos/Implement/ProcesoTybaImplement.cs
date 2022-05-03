using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class ProcesoTybaImplement
    {
        private readonly IMongoCollection<ProcesoTyba> _ProcesoTyba;
        private ProcesoTyba ProcesoTyba;

        public ProcesoTybaImplement(SettingsDatabase procesoTybaDataBase)
        {
            var client = new MongoClient(procesoTybaDataBase.ConnectionString);
            var database = client.GetDatabase(procesoTybaDataBase.MonolegalDatabaseName);

            _ProcesoTyba = database.GetCollection<ProcesoTyba>(procesoTybaDataBase.ProcesosTybaCollectionName);
        }

        public long CuentaProcesoTyba(string id)
        {
            var Query = _ProcesoTyba.Find<ProcesoTyba>(ProcesoTyba => ProcesoTyba.IdAbogado == id).CountDocuments();
            return Query;
        }
            
    }
}
