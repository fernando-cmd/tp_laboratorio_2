using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clasico : Anteojo
    {
        private bool _desmontable;

        #region Propiedades
        /// <summary>
        /// Retorna y asigna si son desmontables
        /// </summary>
        public bool Desmontable { get { return this._desmontable; } set { this._desmontable = value; } }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor publico de un anteojo Clasico y llama al constructor de la clase padre.
        /// </summary>
        /// <param name="desmontable"></param>
        /// <param name="cantidad"></param>
        /// <param name="serie"></param>
        /// <param name="armazon"></param>
        /// <param name="lente"></param>
        /// <param name="color"></param>
        /// <param name="biFocal"></param>
        /// <param name="blueRay"></param>
        public Clasico(bool desmontable, int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
            :base(cantidad,serie,armazon,lente,color,biFocal,blueRay)
        {
            this.Desmontable = desmontable;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"    {this.Desmontable}");
            return sb.ToString();
        }

        #endregion
    }
}
