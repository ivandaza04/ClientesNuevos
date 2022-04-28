using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class FacturaImplement
    {
        private readonly IMongoCollection<Factura> _Facturas;
        private List<Factura> ListaFacturas;
        private Factura Factura;

        public FacturaImplement(SettingsDatabase facturasDatabase)
        {
            var client = new MongoClient(facturasDatabase.ConnectionString);
            var database = client.GetDatabase(facturasDatabase.MonolegalDatabaseName);

            _Facturas = database.GetCollection<Factura>(facturasDatabase.FacturasCollectionName);

            ListaFacturas = new List<Factura>();

            Factura = new Factura();
        }

        public List<Factura> GetFacturas()
        {
            var Query = _Facturas.Find(Factura => true).ToList();
            foreach (Factura result in Query)
                ListaFacturas.Add(new Factura(result._id, result.Codigo, result.IdAbogado, result.FechaCreacion, result.SubTotal));
            return ListaFacturas;
        }

        public Factura CreateFactura(Factura factura)
        {
            _Facturas.InsertOne(factura);
            return factura;
        }
    }
}
