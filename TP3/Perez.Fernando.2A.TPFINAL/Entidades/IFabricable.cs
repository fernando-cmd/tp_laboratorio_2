using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IFabricable
    {        
        int NUMERO_SERIE { get; set; }

        EArmazon ARMAZON { get; set; }
        ELente LENTE { get; set; }
        EColor COLOR { get; set; }
    }
}
