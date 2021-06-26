using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    
    [XmlInclude(typeof(Clasico))]
    [XmlInclude(typeof(Sol))]
    [XmlInclude(typeof(Graduables))]

    public abstract class Anteojo : IFabricable
    {
        protected int _cantidad;
        protected int _numeroSerie;
        protected EArmazon _armazon;
        protected ELente _lente;
        protected EColor _color;
        protected bool _bifocal;
        protected bool _blueRay;

        #region Propiedades
        /// <summary>
        /// Retorna y asigna el numero de serie de la producción.
        /// </summary>
        public virtual int NUMERO_SERIE { get => this._numeroSerie; set => this._numeroSerie = value; }
        /// <summary>
        /// Retorna y asigna el tipo de Armazon a la producción.
        /// </summary>
        public virtual EArmazon ARMAZON { get => this._armazon; set => this._armazon = value; }
        /// <summary>
        /// Retorna y asigna el tipo de Lente a la producción.
        /// </summary>
        public virtual ELente LENTE { get => this._lente; set => this._lente = value; }
        /// <summary>
        /// Retorna y asigna el color a la producción.
        /// </summary>
        public virtual EColor COLOR { get => this._color; set => this._color = value; }
        /// <summary>
        /// Retorna y asigna si los anteojos son BiFocales.
        /// </summary>
        public bool BiFocal { get => this._bifocal; set => this._bifocal = value; }
        /// <summary>
        /// Retorna y asigna si los anteojos cuentan con tecnologia BlueRay.
        /// </summary>
        public bool BlueRay { get => this._blueRay; set => this._blueRay = value; }
        /// <summary>
        /// Retorna y asigna la cantidad de anteojos a producir.
        /// </summary>
        public int Cantidad { get => this._cantidad; set => this._cantidad = value; }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Vacio.
        /// </summary>
        public Anteojo()
        {

        }
        /// <summary>
        /// Contructor de Anteojo
        /// </summary>
        /// <param name="cantidad">Cantidad a producir</param>
        /// <param name="serie">Numero de serie de la producción</param>
        /// <param name="armazon">Tipo de armazon</param>
        /// <param name="lente">Tipo de Lente</param>
        /// <param name="color">Color del marco</param>
        /// <param name="biFocal">Si son o no Bifocales</param>
        /// <param name="blueRay">Si tienen o no la tecnologia BlueRay</param>
        public Anteojo(int cantidad, int serie, EArmazon armazon, ELente lente, EColor color, bool biFocal, bool blueRay)
        {
            this.Cantidad = cantidad;
            this.NUMERO_SERIE = serie;
            this.ARMAZON = armazon;
            this.LENTE = lente;
            this.COLOR = color;
            this.BiFocal = biFocal;
            this.BlueRay = blueRay;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"  {this.NUMERO_SERIE}             {this.Cantidad}           {this.LENTE}       {this.ARMAZON}      {this.COLOR}    " +
                $"      {this.BiFocal}          {this.BlueRay}      ");

            return sb.ToString();

        }

        #endregion
    }
}
