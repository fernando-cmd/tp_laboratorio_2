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
    public partial class frmInformes : Form
    {
        Fabrica fabrica;
        
        public frmInformes()
        {

            InitializeComponent();
            
            
            
        }
        public frmInformes(string nombre) : this()
        {
            this.fabrica = Fabrica.GetFabrica(nombre);
            MessageBox.Show((string)this.fabrica);
            listBox1.DataSource = this.fabrica.Anteojos;

        }

        
    }
}
