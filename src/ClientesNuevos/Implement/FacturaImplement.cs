using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public  class FacturaImplement
    {
        private readonly IMongoCollection<Factura> _Facturas;
        private List<Factura> ListaFacturas;
        private Factura Factura;

        public FacturaImplement()
        {
            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var database = client.GetDatabase("Monolegal");

            _Facturas = database.GetCollection<Factura>("Facturas");

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

    }
}
