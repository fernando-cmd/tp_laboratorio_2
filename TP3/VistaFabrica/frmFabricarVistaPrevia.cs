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
    public partial class frmFabricarVistaPrevia : Form
    {
        Fabrica fabrica;
        public frmFabricarVistaPrevia()
        {
            InitializeComponent();
        }
        
        public frmFabricarVistaPrevia(string nombre):this()
        {
            this.fabrica = Fabrica.GetFabrica(nombre);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmFabricarClasico frmClasico = new frmFabricarClasico(fabrica.Nombre);
            frmClasico.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFabricarSol frmSol = new frmFabricarSol(fabrica.Nombre);
            frmSol.Show();
        }

        private void btnConAumento_Click(object sender, EventArgs e)
        {
            frmFabricarGraduables frmGraduables = new frmFabricarGraduables(fabrica.Nombre);
            frmGraduables.Show();
        }
    }
}
