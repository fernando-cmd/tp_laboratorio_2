using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProduccionRepetidaException : Exception
    {
        public ProduccionRepetidaException():base("Ya se registro una produccion con ese numero de serie.")
        {

        }

    }
}
