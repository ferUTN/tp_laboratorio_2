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

        public frmOsciloscopio()
        {
            InitializeComponent();
        }

        private void frmOsciloscopio_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();


            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
            CargarDatosEnThread();

            this.dgvDatos.SelectionChanged += DgvDatos_SelectionChanged;

        }


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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frmAbm = new frmABMOsciloscopio();
            frmAbm.Actualizado += FrmAbm_Actualizado;
            frmAbm.ShowDialog();
        }

        private void FrmAbm_Actualizado(object sender)
        {
            this.CargarDatosEnThread();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var frmAbm = new frmABMOsciloscopio(this.IdSeleccionado);
            frmAbm.Actualizado += FrmAbm_Actualizado;
            frmAbm.ShowDialog();
        }

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

        private void HabilitarControles(bool habilitar)
        {
            this.btnNuevo.Enabled = habilitar;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.dgvDatos.Enabled = habilitar;
        }
    }
}
