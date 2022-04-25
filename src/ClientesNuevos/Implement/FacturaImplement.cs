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
        private List<Factura> Facturas;
        private Factura Factura;

        public FacturaImplement()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Monolegal");

            _Facturas = database.GetCollection<Factura>("Facturas");

            Facturas = new List<Factura>();

            Factura = new Factura();
        }

        public List<Factura> GetFacturas()
        {
            var Query = _Facturas.Find(Factura => true).ToList();
            foreach (Factura result in Query)
                Facturas.Add(new Factura(result._id, result.Codigo, result.IdAbogado, result.Estado, result.Pagado, result.FechaUltimaComunicacion, result.FechaCreacion, result.InicioFactura, result.FinFactura, result.PathPdf, result.SubTotal, result.RetencionEnFuente, result.Iva, result.Total, result.Token, result.TransactionId, result.TransactionCode, result.TransactionMessage, result.ReferenciaIndividual, result.ReferenciaAgrupada, result.SegundaReferenciaAgrupada, result.FechaTransaccion, result.EsCasoEspecial, result.DescuentoVolumen, result.DescuentoAntiguedad, result.IdProcesoCobro));
            return Facturas;
        }

    }
}
