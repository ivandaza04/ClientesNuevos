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

        public ProcesoTybaImplement()
        {
            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var database = client.GetDatabase("Monolegal");

            _ProcesoTyba = database.GetCollection<ProcesoTyba>("ProcesosTyba");

            ProcesoTyba = new ProcesoTyba();
        }

        public long CuentaProcesoTyba(string id)
        {
            var Query = _ProcesoTyba.Find<ProcesoTyba>(ProcesoTyba => ProcesoTyba.IdAbogado == id).CountDocuments();
            return Query;
        }
            
    }
}
