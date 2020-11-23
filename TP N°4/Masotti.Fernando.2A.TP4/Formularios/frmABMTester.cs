using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensiones;

namespace Formularios
{
    public delegate void delegadoFrmTesterActualizar(object sender);

    public partial class frmABMTester : Form
    {
        public event delegadoFrmTesterActualizar Actualizado;

        private int id;

        public frmABMTester()
        {
            InitializeComponent();
            this.id = 0;
        }

        public frmABMTester(int id) : this()
        {
            this.id = id;            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string cadena = "";
            if (ValidarDatos(out cadena))
            {
                MessageBox.Show(this, cadena, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {

                    var tester = new Tester(this.id, Convert.ToInt32(txtCodigo.Text), txtDescripcion.Text, Convert.ToInt32(nddPrecio.Value), Convert.ToInt32(nddCantidadDeCuentas.Value), Convert.ToInt32(nddCantidadDeFunciones.Value));
                    var adTester = new AccesoDatos.AccesoDatosTester();

                    if (this.id > 0)
                    {
                        adTester.Modificar(tester);
                    }
                    else
                    {
                        adTester.Guardar(tester);
                    }

                    //Si el delegado tiene al menos un handler lo disparo
                    if (Actualizado != null)
                    {
                        this.Actualizado(this);
                    }
                    this.Close();

                    MessageBox.Show("Base de datos de Tester actualizada!", "Actualización de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {                    
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private bool ValidarDatos(out string cadena)
        {
            bool error = false;
            cadena = "ERROR EN LOS DATOS DEL TESTER\n";

            string testerFormateado = this.txtDescripcion.Text;
            this.txtDescripcion.Text = testerFormateado.Formatear();

            if (this.txtDescripcion.Text.Length < 6)
            {
                cadena += "\nLa descripción del tester tiene que tener al menos 6 caracteres.";
                error = true;
            }
            try
            {
                Int32.Parse(this.txtCodigo.Text);
            }
            catch
            {
                cadena += "\nEl código debe ser un númer entero.";
                error = true;                
            }

            return error;
        }


        private void frmABMTester_Load(object sender, EventArgs e)
        {
            if(this.id > 0)
            {
                try
                {
                    var adTester = new AccesoDatos.AccesoDatosTester();
                    var tester = adTester.ObtenerPorId(this.id);
                    this.txtCodigo.Text = tester.Codigo.ToString();
                    this.txtDescripcion.Text = tester.Descripcion;
                    this.nddCantidadDeCuentas.Value = tester.CantidadCuentas;
                    this.nddCantidadDeFunciones.Value = tester.CantidadFunciones;
                    this.nddPrecio.Value = Convert.ToInt32(tester.Precio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
