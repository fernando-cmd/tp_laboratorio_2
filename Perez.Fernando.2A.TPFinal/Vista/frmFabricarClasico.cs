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
    public partial class frmFabricarClasico : Form
    {
        private Clasico anteojo;

        public Clasico Anteojo { get { return this.anteojo; } }
        public frmFabricarClasico()
        {
            InitializeComponent();
            CargarComboBox();
        }


        #region Metodos
        /// <summary>
        /// Carga todos los comboBox del form.
        /// </summary>
        private void CargarComboBox()
        {
            cmbBoxLente.Items.Add(ELente.Plastico);
            cmbBoxLente.Items.Add(ELente.Vidrio);
            cmbBoxLente.SelectedIndex = 1;
            cmbBoxArmazon.Items.Add(EArmazon.Acero);
            cmbBoxArmazon.Items.Add(EArmazon.Aluminio);
            cmbBoxArmazon.Items.Add(EArmazon.Plastico);
            cmbBoxArmazon.SelectedIndex = 1;
            cmbBoxColor.Items.Add(EColor.Blanco);
            cmbBoxColor.Items.Add(EColor.Marron);
            cmbBoxColor.Items.Add(EColor.Negro);
            cmbBoxColor.SelectedIndex = 1;
            cmbBoxBiFocal.Items.Add("Si");
            cmbBoxBiFocal.Items.Add("No");
            cmbBoxBiFocal.SelectedIndex = 1;
            cmbBoxBlueRay.Items.Add("Si");
            cmbBoxBlueRay.Items.Add("No");
            cmbBoxBlueRay.SelectedIndex = 1;
            cmbBoxDesmontable.Items.Add("Si");
            cmbBoxDesmontable.Items.Add("No");
            cmbBoxDesmontable.SelectedIndex = 1;
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnFabricar_Click(object sender, EventArgs e)
        {
            try
            {
                bool biFocal = false;
                bool blueRay = false;
                bool desmontable = false;
                int NUMERO_SERIE = 0;
                int cantidad = 0;
                if(int.Parse(textBoxSerie.Text) > 0)
                {
                    NUMERO_SERIE = int.Parse(textBoxSerie.Text);
                }
                else
                {
                    MessageBox.Show("El N° de serie debe ser mayor a 0");
                }
                if(numericCantidad.Value>0)
                {
                    cantidad = (int)numericCantidad.Value;
                }
                else
                {
                    MessageBox.Show("La cantidad a fabricar debe ser mayor a 0");
                }

                ELente LENTE = (ELente)cmbBoxLente.SelectedItem;
                EArmazon ARMAZON = (EArmazon)cmbBoxArmazon.SelectedItem;
                EColor COLOR = (EColor)cmbBoxColor.SelectedItem;
                
                if(cmbBoxBiFocal.Text == "Si")
                {
                    biFocal = true;
                }
                

                if(cmbBoxBlueRay.Text == "Si")
                {
                    blueRay = true;
                }
                

                if(cmbBoxDesmontable.Text == "Si")
                {
                    desmontable = true;
                }

                this.anteojo = new Clasico(desmontable, cantidad, NUMERO_SERIE, ARMAZON, LENTE, COLOR, biFocal, blueRay);
                this.DialogResult = DialogResult.OK;
                //MessageBox.Show(this.anteojo.ToString());
            }
            catch
            {
                MessageBox.Show("Ingrese todos los campos");
            }
        }
        #endregion
    }
}
