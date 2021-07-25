using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;

namespace Entidades
{
    public class Archivos<T> where T : Anteojo
    {
        /// <summary>
        /// Guarda los anteojos producidos en un archivo XML
        /// </summary>
        /// <param name="Datos"></param>
        public static void GuardarFabrica(DepositoFabrica<T> Datos)
        {
            try
            {
                using (XmlTextWriter auxArchivo = new XmlTextWriter(Datos.DireccionXml, Encoding.UTF8))
                {
                    XmlSerializer auxEscritor = new XmlSerializer(typeof(DepositoFabrica<T>));

                    auxEscritor.Serialize(auxArchivo, Datos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }

        /// <summary>
        /// Lee los datos del archivo XML.
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DepositoFabrica<T> CargarFabrica(DepositoFabrica<T> Datos)
        {
            try
            {
                if (File.Exists(Datos.DireccionXml))
                {
                    using (XmlTextReader auxArchivoLeer = new XmlTextReader(Datos.DireccionXml))
                    {
                        XmlSerializer auxLector = new XmlSerializer(typeof(DepositoFabrica<T>));

                        Datos = (DepositoFabrica<T>)auxLector.Deserialize(auxArchivoLeer);
                    }
                }
                else
                {
                    Console.WriteLine("No existe el archivo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            return Datos;
        }

    }
}
