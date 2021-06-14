using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsuficientesArmazonesException : Exception
    {
        public InsuficientesArmazonesException(string message):base(message)
        {

        }
    }
}
