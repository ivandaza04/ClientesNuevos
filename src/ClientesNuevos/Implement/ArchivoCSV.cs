using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class ArchivoCSV
    {


        public void WriteCVS(string fileName, string informacionfila)
        {
            var titulos = "Id Abogado,Codigo Factura,SubTotal Factura,Fecha Creacion Factura";

            if (!File.Exists(fileName))
            {
                // Crear secuencia de archivo (crear archivo)
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                // Crear un objeto de escritura de secuencia y vincular la secuencia de archivo
                StreamWriter sw = new StreamWriter(fs);
                // Instanciar secuencia de cadena
                StringBuilder sb = new StringBuilder();
                // Agregue datos a la secuencia de cadena (si el título de los datos cambia, modifíquelo aquí)
                sb.Append(titulos);
                // Escribir datos de secuencia de cadena en el archivo
                sw.WriteLine(sb);
                // Actualizar la secuencia del archivo
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            // Escribir objeto para instanciar archivo
            StreamWriter swd = new StreamWriter(fileName, true, Encoding.Default);
            StringBuilder sbd = new StringBuilder();
            // Agregue los datos que se guardarán en la secuencia de cadena
            sbd.Append(informacionfila);
            swd.WriteLine(sbd);
            swd.Flush();
            swd.Close();
        }
    }
}
