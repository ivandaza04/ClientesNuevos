using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Models
{
    public class UsuarioNuevo
    {
        public UsuarioNuevo()
        {
        }

        public UsuarioNuevo(string id, string idAbogado, string codigoFactura, string subTotalFactura, DateTime fechaCreacionFactura)
        {
            _id = id;
            IdAbogado = idAbogado;
            CodigoFactura = codigoFactura;
            SubTotalFactura = subTotalFactura;
            FechaCreacionFactura = fechaCreacionFactura;
        }

        public string _id { get; set; }

        public string IdAbogado { get; set; }

        public string CodigoFactura { get; set; }

        public string SubTotalFactura { get; set; }

        public DateTime FechaCreacionFactura { get; set; }

    }
}
