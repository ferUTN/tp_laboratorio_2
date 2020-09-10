using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{

    /// <summary>
    /// Formulario de la calculadora
    /// </summary>
    public partial class FormCalculadora : Form
    {

        /// <summary>
        /// Constructor de la clase, inicializa los componentes y centra el formulario en la pantalla
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;        
        }


        /// <summary>
        /// Método que realiza la operación matemática y muestra el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(this.txtNumero1.Text != "" && this.txtNumero2.Text != "" && this.cmbOperador.SelectedItem != null) {
                this.lblResultado.Text = Convert.ToString(Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text));
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// Método que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Método que inicializa los operandos, la operación y el resultado
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedItem = null;
        }


        /// <summary>
        /// Método que crea e inicializa los objetos de la clase Numero entre los cuales se va a realizar la operación
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>El resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double retorno= Calculadora.Operar(num1, num2, operador);                
            return retorno;
        }


        /// <summary>
        /// Método que convierte a decimal el resultado (si existe) de la operación anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != "")
            {
                this.lblResultado.Text= Numero.BinarioDecimal(this.lblResultado.Text);
            }
        }


        /// <summary>
        /// Método que convierte a binario el resultado (si existe) de la operación anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != "")
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
            }
        }
    }
}
