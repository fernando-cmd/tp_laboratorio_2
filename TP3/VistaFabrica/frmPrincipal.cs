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
    public partial class FormPrincipal : Form
    {
        Fabrica fabrica;

        #region Constructor
        public FormPrincipal()
        {
            InitializeComponent();
            fabrica = new Fabrica("Fabrica");            
        }
        #endregion

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.Show();
        }

        private void btnFabricar_Click(object sender, EventArgs e)
        {
            fabrica = Fabrica.GetFabrica(fabrica.Nombre);
            frmFabricarVistaPrevia frmVisPrevia = new frmFabricarVistaPrevia(fabrica.Nombre);
            frmVisPrevia.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            fabrica = Fabrica.GetFabrica(fabrica.Nombre);
            frmInformes frmInformes = new frmInformes(fabrica.Nombre);
            frmInformes.Show();
        }
    }
}
