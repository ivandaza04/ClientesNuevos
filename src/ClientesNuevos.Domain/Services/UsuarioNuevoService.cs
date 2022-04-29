﻿using ClientesNuevos.Domain.Models;
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

        public UsuarioNuevoService()
        {
        }

        public UsuarioNuevoService(List<UsuarioNuevo> listaClientesNuevos)
        {
            ListaClientesNuevos = listaClientesNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevos()
        {
            return ListaClientesNuevos;
        }

        public List<UsuarioNuevo> ConsultaClientesNuevosFecha(DateTime fechaMin, DateTime fechaMax)
        {
            foreach (UsuarioNuevo cliente in ListaClientesNuevos)
                if (ClienteNuevoRangoFecha(cliente.FechaCreacionFactura, fechaMin, fechaMax) == true)
                    ListaClientesNuevosFecha.Add(cliente);

            return ListaClientesNuevosFecha;
        }

        // Valora si la FechaCreacion del ClienteNuevo esta en rango de fechas
        public bool ClienteNuevoRangoFecha(DateTime FechaCreacion, DateTime fechaMin, DateTime fechaMax)
        {
            // Compara FechaCreacion con fechaMin, -1 es mayor, 0 es igual, 1 es mayor
            var FacturaAnteriorFechaMin = DateTime.Compare(FechaCreacion, fechaMin);
            // Compara FechaCreacion con fechaMax, -1 es mayor, 0 es igual, 1 es mayor
            var FacturaAnteriorFechaMax = DateTime.Compare(FechaCreacion, fechaMax);

            // Si la fecha Factura es mayor a FechaMin
            if (FacturaAnteriorFechaMin >= 0)
                // Si la fecha Factura es menor a FechaMax
                if (FacturaAnteriorFechaMax <= 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

    }
}
