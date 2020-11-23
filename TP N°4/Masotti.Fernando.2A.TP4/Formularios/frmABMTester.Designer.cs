namespace Formularios
{
    partial class frmABMTester
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nddPrecio = new System.Windows.Forms.NumericUpDown();
            this.nddCantidadDeCuentas = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.nddCantidadDeFunciones = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nddPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nddCantidadDeCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nddCantidadDeFunciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantidad de Cuentas";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(135, 28);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(170, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(135, 67);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(170, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // nddPrecio
            // 
            this.nddPrecio.Location = new System.Drawing.Point(135, 107);
            this.nddPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nddPrecio.Name = "nddPrecio";
            this.nddPrecio.Size = new System.Drawing.Size(170, 20);
            this.nddPrecio.TabIndex = 3;
            // 
            // nddCantidadDeCuentas
            // 
            this.nddCantidadDeCuentas.Location = new System.Drawing.Point(135, 153);
            this.nddCantidadDeCuentas.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nddCantidadDeCuentas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nddCantidadDeCuentas.Name = "nddCantidadDeCuentas";
            this.nddCantidadDeCuentas.Size = new System.Drawing.Size(170, 20);
            this.nddCantidadDeCuentas.TabIndex = 4;
            this.nddCantidadDeCuentas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(135, 246);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(226, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // nddCantidadDeFunciones
            // 
            this.nddCantidadDeFunciones.Location = new System.Drawing.Point(135, 190);
            this.nddCantidadDeFunciones.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nddCantidadDeFunciones.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nddCantidadDeFunciones.Name = "nddCantidadDeFunciones";
            this.nddCantidadDeFunciones.Size = new System.Drawing.Size(170, 20);
            this.nddCantidadDeFunciones.TabIndex = 5;
            this.nddCantidadDeFunciones.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cantidad de Funciones";
            // 
            // frmABMTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 290);
            this.Controls.Add(this.nddCantidadDeFunciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.nddCantidadDeCuentas);
            this.Controls.Add(this.nddPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmABMTester";
            this.Text = "Agregar - Modificar Tester";
            this.Load += new System.EventHandler(this.frmABMTester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nddPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nddCantidadDeCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nddCantidadDeFunciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown nddPrecio;
        private System.Windows.Forms.NumericUpDown nddCantidadDeCuentas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown nddCantidadDeFunciones;
        private System.Windows.Forms.Label label5;
    }
}