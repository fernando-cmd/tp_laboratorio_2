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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza la operacion seleccionada llamando al metodo Operar
        /// y muestra el resultaod de ser posible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(textNumero1.Text, textNumero2.Text, cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Setia los campos seleccionados con "" y 0.
        /// </summary>
        private void Limpiar()
        {
            this.textNumero1.Text = "";
            this.textNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Limpia todos los textbox, comboBox y coloca un '0' en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la operacion sellecionada 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            retorno = Calculadora.Operar(num1, num2, operador);
                                 
            return retorno;
        }

        /// <summary>
        /// En caso de ser posible convierte el resultado de una operacion a numero binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = this.lblResultado.Text;
            Numero num1 = new Numero();
            this.lblResultado.Text = num1.DecimalBinario(numero);
        }

        /// <summary>
        /// En caso de ser posible convierte el resultado de una operacion a numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = this.lblResultado.Text;
            Numero num1 = new Numero();
            this.lblResultado.Text = num1.BinarioDecimal(numero);
        }
    }
}
