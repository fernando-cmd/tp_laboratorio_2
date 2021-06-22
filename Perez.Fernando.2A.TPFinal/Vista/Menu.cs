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
namespace Vista
{
    public partial class Menu : Form
    {
        protected DepositoFabrica<Anteojo> deposito;
        public Menu()
        {
            InitializeComponent();
            this.deposito = new DepositoFabrica<Anteojo>("Fabrica");
        }

        private void btnFabricarClasico_Click(object sender, EventArgs e)
        {
            frmFabricarClasico frmClasico = new frmFabricarClasico();            

            this.Hide();
            if (frmClasico.ShowDialog() == DialogResult.OK)
            {                
                this.deposito += (Anteojo)frmClasico.Anteojo;
            }
            this.Show();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            if(deposito.Lista.Count > 0)
            {
                frmDeposito frmDeposito = new frmDeposito(deposito);
                frmDeposito.Show();
            }
            else
            {
                MessageBox.Show("No fabrico ningun anteojo hasta el momento");
            }
        }

        private void btnFabricarSol_Click(object sender, EventArgs e)
        {
            frmFabricarSol frmSol = new frmFabricarSol();

            this.Hide();
            if(frmSol.ShowDialog() == DialogResult.OK)
            {
                this.deposito += (Anteojo)frmSol.Anteojo;
            }
            this.Show();
        }

        private void btnFabricarGraduable_Click(object sender, EventArgs e)
        {
            frmFabricarGraduable frmGraduable = new frmFabricarGraduable();

            this.Hide();
            if(frmGraduable.ShowDialog() == DialogResult.OK)
            {
                this.deposito += (Anteojo)frmGraduable.Anteojo;
            }
            this.Show();
        }
    }
}
