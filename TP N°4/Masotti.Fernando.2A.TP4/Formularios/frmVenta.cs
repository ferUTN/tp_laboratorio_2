using AccesoDatos;
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
    /// <summary>
    /// Formulario de inicio de la aplicación
    /// </summary>
    public partial class frmVenta : Form
    {
        #region atributos
        private Venta venta;
        private List<Tester> testers;
        private List<Osciloscopio> osciloscopios;

        int idSeleccionado;

        #endregion

        /// <summary>
        /// Constructor por defecto que inicializa los componentes del formulario
        /// </summary>
        public frmVenta()
        {
            InitializeComponent();
            this.idSeleccionado = -1;
        }


        private void frmVenta_Load(object sender, EventArgs e)
        {
            try
            {
                this.venta = new Venta();
                this.ConfigurarGrilla();
                this.txtFecha.Text = DateTime.Now.ToShortDateString();

                this.ActualizarCombos();

                this.dgvProductos.SelectionChanged += this.dgvProductos_SelectionChanged;

            }
            catch (Exception)
            {
                MessageBox.Show(this, "Ha ocurrido un error, intente mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            this.dgvProductos.DataSource = null;
            this.dgvProductos.DataSource = this.venta.Items;
            this.dgvProductos.ClearSelection();
            this.idSeleccionado = -1;
        }


        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvProductos.SelectedRows.Count > 0)
            {
                int index = this.dgvProductos.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvProductos.Rows[index];
                this.idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void AgregarProducto(Producto producto)
        {
            this.venta.Items.Add(producto);
            this.CargarDatos();
        }

        private void btnAgregarTester_Click(object sender, EventArgs e)
        {
            var tester = (Tester)cmbTesters.SelectedItem;
            AgregarProducto(tester);
        }

        private void btnAgregarOsciloscopio_Click(object sender, EventArgs e)
        {
            var osciloscopio = (Osciloscopio)cmbOsciloscopio .SelectedItem;
            AgregarProducto(osciloscopio);
        }

        private void ConfigurarGrilla()
        {
            
            this.dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font(this.dgvProductos.Font, FontStyle.Bold);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvProductos.GridColor = Color.Black;
            this.dgvProductos.ReadOnly = false;
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProductos.RowsDefaultCellStyle.SelectionBackColor = Color.AntiqueWhite;
            this.dgvProductos.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            this.dgvProductos.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dgvProductos.RowHeadersVisible = false;
            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String cadena = "ERROR EN LOS DATOS A FACTURAR\n";
            bool error = false;
            string clienteFormateado = this.txtCliente.Text;
            this.txtCliente.Text= clienteFormateado.Formatear();           
            if(txtCliente.Text.Length < 3)
            {
                cadena += "\nEl nombre de cliente debe tener al menos 3 caracteres.";
                error = true;
            }
            if(this.venta.Items.Count == 0)           
            {
                cadena += "\nLa venta no tiene productos a facturar.";
                error = true;
            }
            if (error)
            {
                MessageBox.Show(this, cadena, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.venta.Cliente = this.txtCliente.Text;
                    this.venta.Fecha= DateTime.Now;
                    this.venta.GenerarArchivosVenta();
                    MessageBox.Show("Archivos escritos correctamente","Generación de factura y serialización de la venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bntTester_Click(object sender, EventArgs e)
        {
            var frmTester = new frmTesters();
            frmTester.ShowDialog();
            this.ActualizarCombos();
        }

        private void ActualizarCombos()
        {
            try
            {
                AccesoDatosTester adTester = new AccesoDatosTester();
                testers = adTester.ObtenerTodos();
                this.cmbTesters.DataSource = testers;
                this.cmbTesters.ValueMember = "Id";
                this.cmbTesters.DisplayMember = "Descripcion";

                AccesoDatosOsciloscopio adOsciloscopio = new AccesoDatosOsciloscopio();
                osciloscopios = adOsciloscopio.ObtenerTodos();
                this.cmbOsciloscopio.DataSource = osciloscopios;
                this.cmbOsciloscopio.ValueMember = "Id";
                this.cmbOsciloscopio.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Actualización de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnOsciloscopio_Click(object sender, EventArgs e)
        {
            var frmOsciloscopio = new frmOsciloscopio();
            frmOsciloscopio.ShowDialog();
            this.ActualizarCombos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int idEliminar = this.idSeleccionado;

            foreach (Producto item in this.venta.Items)
            {
                if(item.Id == idEliminar)
                {
                    this.venta.Items.Remove(item);
                    break;
                }
            }

            this.CargarDatos();

        }


    }
}
