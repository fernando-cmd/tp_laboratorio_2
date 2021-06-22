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

    public partial class frmDeposito : Form
    {
        protected DepositoFabrica<Anteojo> anteojos;
        public frmDeposito(DepositoFabrica<Anteojo> fabrica)
        {
            InitializeComponent();
            anteojos = fabrica;
            MostrarDeposito();
        }

        private void MostrarDeposito()
        {
            richTextBox.Text = anteojos.ToString();
        }
    }
}
