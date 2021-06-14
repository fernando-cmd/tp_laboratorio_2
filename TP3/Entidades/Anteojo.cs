using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Anteojo
    {        
        private int cantidad;
        private EArmazon armazon;
        private ELente lente;
        private bool bifocal;
        private bool blueRay;

        #region Propiedades
        public int Cantidad { get { return this.cantidad; } set { this.cantidad = value; } }
        public EArmazon Armazon { get { return this.armazon; } set { this.armazon = value; } }
        public ELente Lente { get { return this.lente; } set { this.lente = value; } }
        public bool Bifocal { get { return this.bifocal; } set { this.bifocal = value; } }
        public bool BlueRay { get { return this.blueRay; } set { this.blueRay = value; } }
        #endregion

        #region Constructor
        public Anteojo(int cantidad, EArmazon armazon, ELente lente, bool biFocal, bool blueRay)
        {
            this.Cantidad = cantidad;
            this.Armazon = armazon;
            this.Lente = lente;
            this.Bifocal = biFocal;
            this.BlueRay = blueRay;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  Cantidad: {this.Cantidad}");
            sb.AppendLine($"  Lente de: {this.Lente}");
            sb.AppendLine($"  Armazon de: {this.Armazon}");
            sb.AppendLine($"  Bifocal: {this.Bifocal}");
            sb.AppendLine($"  BlueRay: {this.BlueRay}");

            return sb.ToString();
        }
        #endregion
    }
}
