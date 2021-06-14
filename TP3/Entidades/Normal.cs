using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clasico : Anteojo
    {
        private bool desmontable;

        #region Propiedades
        public bool Desmontable { get { return this.desmontable; } set { this.desmontable = value; } }
        #endregion

        #region Constructor
        public Clasico(bool esDesmontable, int cantidad, EArmazon armazon, ELente lente, bool biFocal, bool blueRay)
            : base(cantidad, armazon, lente, biFocal, blueRay)
        {
            this.Desmontable = esDesmontable;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Anteojo Clasico ");
            sb.AppendLine($"   Es Desmontable?: {this.Desmontable.ToString()}");
            sb.AppendLine($" {base.ToString()}");
            return sb.ToString();
        }
        #endregion

    }

}
