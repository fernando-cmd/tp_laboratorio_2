using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.IO;
namespace Entidades
{
    public class Archivos : IArchivos<string>
    {
        //protected string path = 
        public bool Escribir(string datos)
        {
            /*bool retorno = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(Ruta, true))
                {
                    writer.WriteLine(datos);
                    
                    retor = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return agregoInfo;*/
            return true;
        }

        public bool Leer(out string datos)
        {
            throw new NotImplementedException();
        }
    }
}
