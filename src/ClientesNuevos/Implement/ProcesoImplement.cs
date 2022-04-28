using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class ProcesoImplement
    {
        private readonly IMongoCollection<Proceso> _Procesos;
        private Proceso Proceso;

        public ProcesoImplement(SettingsDatabase procesosDatabase)
        {
            var client = new MongoClient(procesosDatabase.ConnectionString);
            var database = client.GetDatabase(procesosDatabase.MonolegalDatabaseName);

            _Procesos = database.GetCollection<Proceso>(procesosDatabase.ProcesosCollectionName);

            Proceso = new Proceso();
        }

        public long CuentaProcesos(string id)
        {
            var Query = _Procesos.Find<Proceso>(Proceso => Proceso.IdAbogado == id).CountDocuments();
            return Query;
        }
            
    }
}
