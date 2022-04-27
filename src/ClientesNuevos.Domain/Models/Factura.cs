using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Models
{
    public class Factura
    {

        public Factura()
        {
        }

        public Factura(string id, string codigo, string idAbogado, DateTime fechaCreacion, string subTotal)
        {
            _id = id;
            Codigo = codigo;
            IdAbogado = idAbogado;
            FechaCreacion = fechaCreacion;
            SubTotal = subTotal;
        }
        public string _id { get; set; }

        public string Codigo { get; set; }

        public string IdAbogado { get; set; }

        public string Estado { get; set; }

        public bool Pagado { get; set; }

        public DateTime FechaUltimaComunicacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime InicioFactura { get; set; }

        public DateTime FinFactura { get; set; }

        public string PathPdf { get; set; }

        public string SubTotal { get; set; }

        public string RetencionEnFuente { get; set; }

        public string Iva { get; set; }

        public string Total { get; set; }

        public string Token { get; set; }

        public string TransactionId { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionMessage { get; set; }

        public string ReferenciaIndividual { get; set; }

        public string ReferenciaAgrupada { get; set; }

        public string SegundaReferenciaAgrupada { get; set; }

        public DateTime FechaTransaccion { get; set; }

        public bool EsCasoEspecial { get; set; }

        public bool DescuentoVolumen { get; set; }

        public bool DescuentoAntiguedad { get; set; }

        public string IdProcesoCobro { get; set; }

    }
}
