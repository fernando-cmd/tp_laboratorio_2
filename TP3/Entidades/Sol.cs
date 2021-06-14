using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sol : Anteojo
    {
        private bool polarizado;
        private EColor colorMarco;
        private EColor colorLente;

        #region Propiedades
        public bool Polarizado { get { return this.polarizado; } set { this.polarizado = value; } }
        public EColor ColorMarco { get { return this.colorMarco; } set { this.colorMarco = value; } }
        public EColor ColorLente { get { return this.colorLente; } set { this.colorLente = value; } }
        #endregion

        #region Constructor
        public Sol(bool polarizado, int cantidad, EArmazon armazon, ELente lente, bool biFocal, bool blueRay, EColor colorMarco, EColor colorLente)
            : base(cantidad, armazon, lente, biFocal, blueRay)
        {
            this.polarizado = polarizado;
            this.colorMarco = colorMarco;
            this.colorLente = colorLente;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lente de Sol");
            sb.AppendLine($"Color del marco: {this.ColorMarco.ToString()}");
            sb.AppendLine($"Color del lente: {this.ColorLente.ToString()}");
            sb.AppendLine($"{base.ToString()}");
            return sb.ToString();
        }
        #endregion
    }
}
