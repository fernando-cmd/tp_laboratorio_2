using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Entidades
{
    [Serializable]
    public class Graduables : Clasico
    {
        private double _ojoIzquierdo;
        private double _ojoDerecho;

        #region Propiedades
        /// <summary>
        /// Retorna y asigna la graduacion del ojo izquierdo.
        /// </summary>
        public double OjoIzquierdo { get { return this._ojoIzquierdo; } set { this._ojoIzquierdo = value; } }
        /// <summary>
        /// Retorna y asigna la graduacion del ojo derecho.
        /// </summary>
        public double OjoDerecho { get { return this._ojoDerecho; } set { this._ojoDerecho = value; } }
        #endregion
        
        #region Constructores
        public Graduables()
        {

        }
        /// <summary>
        /// Constructor publico de un anteojo con graduacion.
        /// </summary>
        /// <param name="ojoIzquierdo">Aumento ojo izquierdo</param>
        /// <param name="ojoDerecho">Aumento ojo derecho</param>
        /// <param name="desmontable"></param>
        /// <param name="cantidad"></param>
        /// <param name="serie"></param>
        /// <param name="armazon"></param>
        /// <param name="lente"></param>
        /// <param name="color"></param>
        /// <param name="biFocal"></param>
        /// <param name="blueRay"></param>
        public Graduables(double ojoIzquierdo, double ojoDerecho, bool desmontable, int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
            : base(desmontable, cantidad, serie, armazon, lente, color, biFocal, blueRay)
        {
            this.OjoIzquierdo = ojoIzquierdo;
            this.OjoDerecho = ojoDerecho;
        }
        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Ojo izquierdo: {this.OjoIzquierdo}");
            sb.AppendLine($"Ojo derecho: {this.OjoDerecho}");
            sb.AppendLine("********************");
            return sb.ToString();
        }
        #endregion
    }
}
