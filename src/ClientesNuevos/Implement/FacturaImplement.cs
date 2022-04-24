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
            var Result = _Facturas.Find(Factura => true).ToList();
            foreach (Factura f in Result)
                Facturas.Add(new Factura(f._id, f.Codigo, f.IdAbogado, f.Estado, f.Pagado, f.FechaUltimaComunicacion, f.FechaCreacion, f.InicioFactura, f.FinFactura, f.PathPdf, f.SubTotal, f.RetencionEnFuente, f.Iva, f.Total, f.Token, f.TransactionId, f.TransactionCode, f.TransactionMessage, f.ReferenciaIndividual, f.ReferenciaAgrupada, f.SegundaReferenciaAgrupada, f.FechaTransaccion, f.EsCasoEspecial, f.DescuentoVolumen, f.DescuentoAntiguedad, f.IdProcesoCobro));
            return Facturas;
        }
    }
}
