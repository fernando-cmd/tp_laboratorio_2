using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        #region Constructor
        public Menu()
        {
            InitializeComponent();
            this.deposito = new DepositoFabrica<Anteojo>("Fabrica");
            this.deposito.DireccionXml = AppDomain.CurrentDomain.BaseDirectory + "AnteojosProducidos.xml";
        }
        #endregion

        #region Eventos
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

            //AbriFormPanel(new frmFabricarSol());
            
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.deposito.Lista.Count > 0)
            {
                Archivos<Anteojo>.GuardarFabrica(this.deposito);
                MessageBox.Show("Se guardaron los datos correctamente");
            }
            else
            {
                MessageBox.Show("No se han producido anteojos hasta el momento");
            }
        }

        #endregion

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (File.Exists(deposito.DireccionXml))
            {
                DialogResult Confirmacion;

                Confirmacion = MessageBox.Show("¿ Desea cargar los datos XML de los productos fabricados ? Se van a sobreescribir los datos actuales", "Acuerdo legal", MessageBoxButtons.OKCancel);

                if (Confirmacion == DialogResult.OK)
                {
                    deposito = Archivos<Anteojo>.CargarFabrica(deposito);
                    MessageBox.Show("Se cargaron los datos del XML", "Cargado correctamente");
                }
            }
            else
            {
                MessageBox.Show("No existe el archivo para ser cargado, pruebe guardando por primera vez los datos", "Error al cargar el XML");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbriFormPanel(object form)
        {
            if(this.panelContenedor.Controls.Count>0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Hide();
        }

    }
}
