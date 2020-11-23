using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Formularios
{
    public partial class frmOsciloscopio : Form
    {

        private int IdSeleccionado = -1;
        private Thread hiloCargarDatos;

        /// <summary>
        /// Constructor por defecto que inicializa los componentes del formulario
        /// </summary>
        public frmOsciloscopio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al cargar el form se configura la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOsciloscopio_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();

            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
            CargarDatosEnThread();

            this.dgvDatos.SelectionChanged += DgvDatos_SelectionChanged;

        }

        /// <summary>
        /// Si se eligió un osciloscopio se habilitan los botones Eliminar y Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.btnEliminar.Enabled = true;
                this.btnModificar.Enabled = true;

                int index = this.dgvDatos.CurrentCell.RowIndex;
                DataGridViewRow row = this.dgvDatos.Rows[index];
                this.IdSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        /// <summary>
        /// Método que configura la grilla
        /// </summary>
        private void ConfigurarGrilla()
        {

            this.dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font(this.dgvDatos.Font, FontStyle.Bold);
            this.dgvDatos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvDatos.GridColor = Color.Black;
            this.dgvDatos.ReadOnly = false;
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvDatos.RowsDefaultCellStyle.SelectionBackColor = Color.AntiqueWhite;
            this.dgvDatos.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            this.dgvDatos.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dgvDatos.ClearSelection();

            this.dgvDatos.RowHeadersVisible = false;
        }

        /// <summary>
        /// Método para cargar un nuevo osciloscopio en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frmAbm = new frmABMOsciloscopio();
            frmAbm.Actualizado += FrmAbm_Actualizado;
            frmAbm.ShowDialog();
        }

        /// <summary>
        /// Handler del evento Actualizado para refrescar la grilla
        /// </summary>
        /// <param name="sender"></param>
        private void FrmAbm_Actualizado(object sender)
        {
            this.CargarDatosEnThread();
        }

        /// <summary>
        /// Método para modificar un osciloscopio de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var frmAbm = new frmABMOsciloscopio(this.IdSeleccionado);
            frmAbm.Actualizado += FrmAbm_Actualizado;
            frmAbm.ShowDialog();
        }

        /// <summary>
        /// Método para eliminar un osciloscopio de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = this.IdSeleccionado;
            try
            {
                AccesoDatosOsciloscopio adOsciloscopio = new AccesoDatosOsciloscopio();
                adOsciloscopio.Eliminar(idEliminar);
                this.CargarDatosEnThread();
                MessageBox.Show("Osciloscopio eliminado!", "Actualización de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicio del hilo para cargar los datos en la grilla
        /// </summary>
        private void CargarDatosEnThread()
        {
            this.HabilitarControles(false);
            this.hiloCargarDatos = new Thread(this.CargarDatos);
            this.hiloCargarDatos.Start();
        }

        /// <summary>
        /// Metodo que hace el Invoke para poder acceder a los controles del formulario desde otro Hilo
        /// </summary>
        private void CargarDatos()
        {
            Invoke(new MethodInvoker(this.CargarDatosInvoker));
        }

        /// <summary>
        /// Metodo que respeta la firma del delegado MethodInvoker para poder acceder a
        /// los controles del formulario dentro de otro Hilo (diferente al del formulario)
        /// </summary>
        private void CargarDatosInvoker()
        {
            try
            {
                AccesoDatosOsciloscopio adOsciloscopio = new AccesoDatosOsciloscopio();
                this.dgvDatos.DataSource = null;
                this.dgvDatos.DataSource = adOsciloscopio.ObtenerTodos();
                this.dgvDatos.ClearSelection();
                this.HabilitarControles(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Actualización de la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Método paa habilitar o desabilitar los botones
        /// </summary>
        /// <param name="habilitar"></param>
        private void HabilitarControles(bool habilitar)
        {
            this.btnNuevo.Enabled = habilitar;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.dgvDatos.Enabled = habilitar;
        }
    }
}
