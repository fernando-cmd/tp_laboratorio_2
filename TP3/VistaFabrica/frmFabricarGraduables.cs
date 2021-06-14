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
    public partial class frmFabricarGraduables : Form
    {
        Fabrica fabrica;
        Graduables anteojo;
        public frmFabricarGraduables()
        {
            InitializeComponent();
            ItemsCombobox();
        }

        public frmFabricarGraduables(string nombre) : this()
        {
            this.fabrica = Fabrica.GetFabrica(nombre);
        }
        public Fabrica Fabrica { get { return fabrica; } }

        private void ItemsCombobox()
        {
            cmbBoxLente.Items.Add(ELente.Metal);
            cmbBoxLente.Items.Add(ELente.Plastico);
            cmbBoxLente.Items.Add(ELente.Vidrio);
            cmbBoxArmazon.Items.Add(EArmazon.Acero);
            cmbBoxArmazon.Items.Add(EArmazon.Aluminio);
            cmbBoxArmazon.Items.Add(EArmazon.Plastico);
            cmbBoxBiFocal.Items.Add("Si");
            cmbBoxBiFocal.Items.Add("No");
            cmbBoxBlue.Items.Add("Si");
            cmbBoxBlue.Items.Add("No");
            cmbBoxDesmontable.Items.Add("Si");
            cmbBoxDesmontable.Items.Add("No");

            cmbBoxArmazon.SelectedIndex = 0;
            cmbBoxBlue.SelectedIndex = 1;
            cmbBoxDesmontable.SelectedIndex = 1;
            cmbBoxBiFocal.SelectedIndex = 1;
            cmbBoxLente.SelectedIndex = 0;
        }

        private void btnProducir_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value > 0)
                {
                    if (StockInsumos.ValidarStockArmazon((EArmazon)cmbBoxArmazon.SelectedItem, (int)numericUpDown1.Value) &&
                        StockInsumos.ValidarStockLentes((ELente)cmbBoxLente.SelectedItem, (int)numericUpDown1.Value))
                    {
                        bool desmontable = false;
                        bool bifocal = false;
                        bool blueRay = false;
                        if (cmbBoxBiFocal.Text == "Si")
                        {
                            bifocal = true;
                        }
                        if (cmbBoxBlue.Text == "Si")
                        {
                            blueRay = true;
                        }
                        if (cmbBoxDesmontable.Text == "Si")
                        {
                            desmontable = true;
                        }
                        anteojo = new Graduables((float)numericOI.Value,(float)numericOD.Value,desmontable, (int)numericUpDown1.Value, (EArmazon)cmbBoxArmazon.SelectedItem, (ELente)cmbBoxLente.SelectedItem, bifocal, blueRay);
                        fabrica.Agregar(anteojo);
                        MessageBox.Show("Fabricacion exitosa!!");

                    }
                }
                else
                {
                    MessageBox.Show("La cantidad a fabricar debe ser mayor a 0");
                }
            }
            catch(InsuficientesArmazonesException eArmazon)
            {
                MessageBox.Show(eArmazon.Message, "Insuficientes armazones");
            }
            catch(InsuficientesLentesException eLente)
            {
                MessageBox.Show(eLente.Message, "Insuficientes lentes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
