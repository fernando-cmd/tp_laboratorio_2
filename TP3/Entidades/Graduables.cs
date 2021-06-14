using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Graduables : Clasico
    {
        private float ojoIzquierdo;
        private float ojoDerecho;

        #region Propiedades
        public float OjoIzquierdo { get { return this.ojoIzquierdo; } set {this.ojoIzquierdo = value; } }
        public float OjoDerecho { get { return this.ojoDerecho; } set {this.ojoDerecho = value; } }
        #endregion

        #region Contructor
        public Graduables(float oIzquierdo, float oDerecho, bool esDesmontable, int cantidad, EArmazon armazon, ELente lente, bool biFocal, bool blueRay)
            :base(esDesmontable,cantidad,armazon,lente,biFocal,blueRay)
        {
            this.OjoIzquierdo = oIzquierdo;
            this.OjoDerecho = oDerecho;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aumento OI: {this.OjoIzquierdo} - Aumento OD: {this.OjoDerecho}");
            sb.AppendLine($"{base.ToString()}");
            return sb.ToString();
        }
        #endregion
    }
}
