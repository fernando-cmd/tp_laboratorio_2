using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace VistaFabrica
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
            actualizarStock();
        }

        public void actualizarStock()
        {
            this.textBoxMetal.Text = StockInsumos.LentesMetal.ToString();
            this.textBoxPlastico.Text = StockInsumos.LentesPlastico.ToString();
            this.textBoxVidrio.Text = StockInsumos.LentesVidrio.ToString();
            this.txtBoxAcero.Text = StockInsumos.ArmazonAcero.ToString();
            this.txtBoxAluminio.Text = StockInsumos.ArmazonAluminio.ToString();
            this.txtBoxPlasticoArmazon.Text = StockInsumos.ArmazonPlastico.ToString();
        }


        private void btnAgregarLentes_Click(object sender, EventArgs e)
        {
            if(numLenMetal.Value > 0)
            {
                StockInsumos.AgregarLentes(ELente.Metal, (int)numLenMetal.Value);
            }
            if(numLenPlastico.Value > 0)
            {
                StockInsumos.AgregarLentes(ELente.Plastico, (int)numLenPlastico.Value);
            }
            if(numLenVidrio.Value > 0)
            {
                StockInsumos.AgregarLentes(ELente.Vidrio, (int)numLenVidrio.Value);
            }
            actualizarStock();
        }

        private void btnAgregarArmazones_Click(object sender, EventArgs e)
        {
            if (numArmAluminio.Value > 0)
            {
                StockInsumos.AgregarArmazones(EArmazon.Aluminio, (int)numArmAluminio.Value);
            }
            if (numArmAcero.Value > 0)
            {
                StockInsumos.AgregarArmazones(EArmazon.Acero, (int)numArmAcero.Value);
            }
            if (numArmPlastico.Value > 0)
            {
                StockInsumos.AgregarArmazones(EArmazon.Plastico,  (int)numArmPlastico.Value);
            }
            actualizarStock();
        }
    }
}
