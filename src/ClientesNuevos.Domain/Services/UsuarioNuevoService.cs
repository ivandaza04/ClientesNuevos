using ClientesNuevos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class UsuarioNuevoService
    {
        List<UsuarioNuevo> ListaClientesNuevos = new List<UsuarioNuevo>();
        List<UsuarioNuevo> ListaClientesNuevosFecha = new List<UsuarioNuevo>();
        DateTime fechaMin;
        DateTime fechaMax;

        public UsuarioNuevoService(List<UsuarioNuevo> listaClientesNuevos, DateTime fechaMin, DateTime fechaMax)
        {
            ListaClientesNuevos = listaClientesNuevos;
            this.fechaMin = fechaMin;
            this.fechaMax = fechaMax;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevos()
        {
            return ListaClientesNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevosFecha()
        {
            foreach (UsuarioNuevo usuario in ListaClientesNuevos)
                AgregarUsuarioNuevoFecha(usuario);

            return ListaClientesNuevosFecha;
        }

        public void AgregarUsuarioNuevoFecha(UsuarioNuevo usuario)
        {
            RangoFechaService rangoFecha = new RangoFechaService(fechaMin, fechaMax);
            if (rangoFecha.ValidarRangoFecha(usuario.FechaCreacionFactura) == true)
                ListaClientesNuevosFecha.Add(usuario);
        }

    }
}
