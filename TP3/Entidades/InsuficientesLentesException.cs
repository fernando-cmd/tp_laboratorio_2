using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsuficientesLentesException : Exception
    {
        public InsuficientesLentesException(string message):base(message)
        {

        }
    }
}
