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
using Entidades;

namespace Formularios
{
    public delegate void delegadoFrmOsciloscopioActualizar(object sender);

    public partial class frmABMOsciloscopio : Form
    {
        public event delegadoFrmOsciloscopioActualizar Actualizado;

        private int id;

        public frmABMOsciloscopio()
        {
            InitializeComponent();
            this.id = 0;
        }

        public frmABMOsciloscopio(int id) : this()
        {
            this.id = id;
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

                    var osciloscopio = new Osciloscopio(this.id, Convert.ToInt32(txtCodigo.Text), txtDescripcion.Text, Convert.ToInt32(nddPrecio.Value), this.chkPuertoUsb.Checked, this.chkPortatil.Checked);
                    var adOsciloscopio = new AccesoDatos.AccesoDatosOsciloscopio();

                    if (this.id > 0)
                    {
                        adOsciloscopio.Modificar(osciloscopio);
                    }
                    else
                    {
                        adOsciloscopio.Guardar(osciloscopio);
                    }

                    //Si el delegado tiene al menos un handler lo disparo
                    if (Actualizado != null)
                    {
                        this.Actualizado(this);
                    }
                    this.Close();

                    MessageBox.Show("Base de datos de Osciloscopio actualizada!", "Actualización de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            cadena = "ERROR EN LOS DATOS DEL OSCILOSCOPIO\n";

            string osciloscopioFormateado = this.txtDescripcion.Text;
            this.txtDescripcion.Text = osciloscopioFormateado.Formatear();

            if (this.txtDescripcion.Text.Length < 6)
            {
                cadena += "\nLa descripción del osciloscopio tiene que tener al menos 6 caracteres.";
                error = true;
            }
            try
            {
                Int32.Parse(this.txtCodigo.Text);
            }
            catch
            {
                cadena += "\nEl código debe ser un número entero.";
                error = true;
            }

            return error;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMOsciloscopio_Load(object sender, EventArgs e)
        {
            if (this.id > 0)
            {
                try
                {
                    var adOsciloscopio = new AccesoDatos.AccesoDatosOsciloscopio();
                    var osciloscopio = adOsciloscopio.ObtenerPorId(this.id);
                    this.txtCodigo.Text = osciloscopio.Codigo.ToString();
                    this.txtDescripcion.Text = osciloscopio.Descripcion;
                    this.chkPuertoUsb.Checked = osciloscopio.PuertoUsb;
                    this.chkPortatil.Checked = osciloscopio.Portatil;
                    this.nddPrecio.Value = Convert.ToInt32(osciloscopio.Precio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
