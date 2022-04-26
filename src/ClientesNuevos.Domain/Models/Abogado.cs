using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Models
{
    public class Abogado
    {

        public string _id { get; set; }

        public Boolean Activo { get; set; }

        public Boolean Borrado { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public int Version { get; set; }

        public int NumProcesos { get; set; }

        public string CuentaPrincipal { get; set; }

        public string Master { get; set; }

        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime UltimoCambio { get; set; }

        public Boolean DatosFacturacion { get; set; }

        public DateTime FechaUltimaFactura { get; set; }

        public DateTime FechaProximaFactura { get; set; }

        public string NumeroAsociado { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public string Nit { get; set; }

        public string RazonSocial { get; set; }

        public string TipoDeEnvioNotificaciones { get; set; }

        public string TipoCliente { get; set; }

        public string PlanPorDefecto { get; set; }

        public string TipoUsuario { get; set; }

        public Boolean CasoEspecial { get; set; }

        public Boolean Banco { get; set; }

        public Boolean NotificarUnificada { get; set; }

        public Boolean DesactivadoPorFaltaDePago { get; set; }

        public Boolean DesactivacionTotal { get; set; }

        public DateTime FechaInicioFactura { get; set; }

        public Abogado()
        {
        }

        public Abogado(string id, bool activo, string nombre, string email, string ciudad)
        {
            _id = id;
            Activo = activo;
            Nombre = nombre;
            Email = email;
            Ciudad = ciudad;
        }
    }
}
