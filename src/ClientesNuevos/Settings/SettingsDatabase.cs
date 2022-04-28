using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class SettingsDatabase
    {
        public string ConnectionString { get; set; } = "mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017";

        public string MonolegalDatabaseName { get; set; } = "Monolegal";

        public string SGPDatabaseName { get; set; } = "SGP";

        public string FacturasCollectionName { get; set; } = "Facturas";

        public string ClientesNuevosCollectionName { get; set; } = "ClientesNuevos";

        public string ProcesosTybaCollectionName { get; set; } = "ProcesosTyba";

        public string ProcesosCollectionName { get; set; } = "Procesos";

        public string AbogadosCollectionName { get; set; } = "Abogados";
    }
}
