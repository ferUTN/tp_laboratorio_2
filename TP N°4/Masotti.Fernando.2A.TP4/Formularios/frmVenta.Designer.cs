namespace Formularios
{
    partial class frmVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimirFactura = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnABMOsciloscopio = new System.Windows.Forms.Button();
            this.bntABMTester = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarOsciloscopio = new System.Windows.Forms.Button();
            this.btnAgregarTester = new System.Windows.Forms.Button();
            this.cmbOsciloscopio = new System.Windows.Forms.ComboBox();
            this.cmbTesters = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(714, 445);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimirFactura
            // 
            this.btnImprimirFactura.Location = new System.Drawing.Point(591, 445);
            this.btnImprimirFactura.Name = "btnImprimirFactura";
            this.btnImprimirFactura.Size = new System.Drawing.Size(101, 23);
            this.btnImprimirFactura.TabIndex = 9;
            this.btnImprimirFactura.Text = "Imprimir Factura";
            this.btnImprimirFactura.UseVisualStyleBackColor = true;
            this.btnImprimirFactura.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // btnABMOsciloscopio
            // 
            this.btnABMOsciloscopio.Location = new System.Drawing.Point(261, 12);
            this.btnABMOsciloscopio.Name = "btnABMOsciloscopio";
            this.btnABMOsciloscopio.Size = new System.Drawing.Size(112, 23);
            this.btnABMOsciloscopio.TabIndex = 5;
            this.btnABMOsciloscopio.TabStop = false;
            this.btnABMOsciloscopio.Text = "ABM Osciloscopio";
            this.btnABMOsciloscopio.UseVisualStyleBackColor = true;
            this.btnABMOsciloscopio.Click += new System.EventHandler(this.btnOsciloscopio_Click);
            // 
            // bntABMTester
            // 
            this.bntABMTester.Location = new System.Drawing.Point(88, 12);
            this.bntABMTester.Name = "bntABMTester";
            this.bntABMTester.Size = new System.Drawing.Size(112, 23);
            this.bntABMTester.TabIndex = 0;
            this.bntABMTester.TabStop = false;
            this.bntABMTester.Text = "ABM Tester";
            this.bntABMTester.UseVisualStyleBackColor = true;
            this.bntABMTester.Click += new System.EventHandler(this.bntTester_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(115, 55);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(341, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(115, 90);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(341, 20);
            this.txtFecha.TabIndex = 7;
            this.txtFecha.TabStop = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(39, 229);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(545, 194);
            this.dgvProductos.TabIndex = 8;
            this.dgvProductos.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(39, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la venta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarOsciloscopio);
            this.groupBox2.Controls.Add(this.btnAgregarTester);
            this.groupBox2.Controls.Add(this.cmbOsciloscopio);
            this.groupBox2.Controls.Add(this.cmbTesters);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(39, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 78);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // btnAgregarOsciloscopio
            // 
            this.btnAgregarOsciloscopio.Location = new System.Drawing.Point(340, 45);
            this.btnAgregarOsciloscopio.Name = "btnAgregarOsciloscopio";
            this.btnAgregarOsciloscopio.Size = new System.Drawing.Size(69, 23);
            this.btnAgregarOsciloscopio.TabIndex = 7;
            this.btnAgregarOsciloscopio.Text = "Agregar";
            this.btnAgregarOsciloscopio.UseVisualStyleBackColor = true;
            this.btnAgregarOsciloscopio.Click += new System.EventHandler(this.btnAgregarOsciloscopio_Click);
            // 
            // btnAgregarTester
            // 
            this.btnAgregarTester.Location = new System.Drawing.Point(340, 17);
            this.btnAgregarTester.Name = "btnAgregarTester";
            this.btnAgregarTester.Size = new System.Drawing.Size(69, 23);
            this.btnAgregarTester.TabIndex = 5;
            this.btnAgregarTester.Text = "Agregar";
            this.btnAgregarTester.UseVisualStyleBackColor = true;
            this.btnAgregarTester.Click += new System.EventHandler(this.btnAgregarTester_Click);
            // 
            // cmbOsciloscopio
            // 
            this.cmbOsciloscopio.FormattingEnabled = true;
            this.cmbOsciloscopio.Location = new System.Drawing.Point(87, 46);
            this.cmbOsciloscopio.Name = "cmbOsciloscopio";
            this.cmbOsciloscopio.Size = new System.Drawing.Size(247, 21);
            this.cmbOsciloscopio.TabIndex = 6;
            // 
            // cmbTesters
            // 
            this.cmbTesters.FormattingEnabled = true;
            this.cmbTesters.Location = new System.Drawing.Point(87, 17);
            this.cmbTesters.Name = "cmbTesters";
            this.cmbTesters.Size = new System.Drawing.Size(247, 21);
            this.cmbTesters.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Osciloscopio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tester";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(591, 229);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(101, 23);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 480);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnABMOsciloscopio);
            this.Controls.Add(this.bntABMTester);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirFactura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVenta";
            this.Text = "Formulario de ventas -  Fernando Masotti 2°A";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimirFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnABMOsciloscopio;
        private System.Windows.Forms.Button bntABMTester;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOsciloscopio;
        private System.Windows.Forms.ComboBox cmbTesters;
        private System.Windows.Forms.Button btnAgregarOsciloscopio;
        private System.Windows.Forms.Button btnAgregarTester;
        private System.Windows.Forms.Button btnQuitar;
    }
}