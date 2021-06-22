using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sol : Anteojo
    {
        private bool _polarizado;

        #region Propiedades
        /// <summary>
        /// Retorna y asigna si es un anteojo polarizado.
        /// </summary>
        public bool Polarizado { get { return this._polarizado; } set { this._polarizado = value; } }
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor publico de un anteojo de sol y llama al constructor de la clase padre.
        /// </summary>
        /// <param name="polarizado"></param>
        /// <param name="cantidad"></param>
        /// <param name="serie"></param>
        /// <param name="armazon"></param>
        /// <param name="lente"></param>
        /// <param name="color"></param>
        /// <param name="biFocal"></param>
        /// <param name="blueRay"></param>
        public Sol(bool polarizado, int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
            : base(cantidad, serie, armazon, lente, color, biFocal, blueRay)
        {
            this.Polarizado = polarizado;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"    {this.Polarizado}");

            return sb.ToString();
        }
        #endregion
    }
}