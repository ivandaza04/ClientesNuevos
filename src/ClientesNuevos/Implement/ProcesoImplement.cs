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

        public ProcesoImplement()
        {
            //var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Monolegal");

            _Procesos = database.GetCollection<Proceso>("Procesos");

            Proceso = new Proceso();
        }

        public long CuentaProcesos(string id)
        {
            var Query = _Procesos.Find<Proceso>(Proceso => Proceso.IdAbogado == id).CountDocuments();
            return Query;
        }
            
    }
}
