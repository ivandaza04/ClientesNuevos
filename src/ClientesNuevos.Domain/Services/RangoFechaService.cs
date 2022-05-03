using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Domain.Services
{
    public class RangoFechaService
    {
        DateTime FechaMin { get; set; }

        DateTime FechaMax { get; set; }

        public RangoFechaService(DateTime fechaMin, DateTime fechaMax)
        {
            FechaMin = fechaMin;
            FechaMax = fechaMax;
        }


        // Valora si la FechaCreacion de la factura esta en rango de fechas
        public bool ValidarRangoFecha(DateTime FechaCreacion)
        {
            // Compara FechaCreacion con fechaMin, -1 es mayor, 0 es igual, 1 es mayor
            var AnteriorFechaMin = DateTime.Compare(FechaCreacion, FechaMin);
            // Compara FechaCreacion con fechaMax, -1 es mayor, 0 es igual, 1 es mayor
            var AnteriorFechaMax = DateTime.Compare(FechaCreacion, FechaMax);

            // Si la fecha Factura es mayor a FechaMin
            if (AnteriorFechaMin >= 0)
                // Si la fecha Factura es menor a FechaMax
                if (AnteriorFechaMax <= 0)
                    return true;
                else
                    return false;
            else
                return false;
        }
    }
}
