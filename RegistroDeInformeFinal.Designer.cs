namespace proyectoPantalla
{
    partial class RegistroDeInformeFinal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lMostrarCliente = new System.Windows.Forms.Label();
            this.lNumCaso = new System.Windows.Forms.Label();
            this.tbInformeFinal = new System.Windows.Forms.TextBox();
            this.lInformeFinal = new System.Windows.Forms.Label();
            this.lMostrarTecnico = new System.Windows.Forms.Label();
            this.lTecnicoAsignado = new System.Windows.Forms.Label();
            this.lCliente = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.lMostrarCaso = new System.Windows.Forms.Label();
            this.lVendendor = new System.Windows.Forms.Label();
            this.lMostrarVendedor = new System.Windows.Forms.Label();
            this.lImagen = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bSeleccionar = new System.Windows.Forms.Button();
            this.labelImagen = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lMostrarCliente, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lNumCaso, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbInformeFinal, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lInformeFinal, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lMostrarTecnico, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lTecnicoAsignado, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lCliente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lMostrarCaso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lVendendor, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lMostrarVendedor, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lImagen, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 374);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lMostrarCliente
            // 
            this.lMostrarCliente.AutoSize = true;
            this.lMostrarCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMostrarCliente.Location = new System.Drawing.Point(99, 0);
            this.lMostrarCliente.Name = "lMostrarCliente";
            this.lMostrarCliente.Size = new System.Drawing.Size(476, 53);
            this.lMostrarCliente.TabIndex = 41;
            this.lMostrarCliente.Text = "NOMBRE DEL CLIENTE";
            this.lMostrarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lNumCaso
            // 
            this.lNumCaso.AutoSize = true;
            this.lNumCaso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNumCaso.Location = new System.Drawing.Point(3, 53);
            this.lNumCaso.Name = "lNumCaso";
            this.lNumCaso.Size = new System.Drawing.Size(90, 53);
            this.lNumCaso.TabIndex = 1;
            this.lNumCaso.Text = "Número de caso:";
            this.lNumCaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbInformeFinal
            // 
            this.tbInformeFinal.Location = new System.Drawing.Point(99, 215);
            this.tbInformeFinal.MaxLength = 1024;
            this.tbInformeFinal.Multiline = true;
            this.tbInformeFinal.Name = "tbInformeFinal";
            this.tbInformeFinal.Size = new System.Drawing.Size(476, 37);
            this.tbInformeFinal.TabIndex = 26;
            // 
            // lInformeFinal
            // 
            this.lInformeFinal.AutoSize = true;
            this.lInformeFinal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lInformeFinal.Location = new System.Drawing.Point(23, 212);
            this.lInformeFinal.Name = "lInformeFinal";
            this.lInformeFinal.Size = new System.Drawing.Size(70, 53);
            this.lInformeFinal.TabIndex = 1;
            this.lInformeFinal.Text = "Informe Final:";
            // 
            // lMostrarTecnico
            // 
            this.lMostrarTecnico.AutoSize = true;
            this.lMostrarTecnico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMostrarTecnico.Location = new System.Drawing.Point(99, 106);
            this.lMostrarTecnico.Name = "lMostrarTecnico";
            this.lMostrarTecnico.Size = new System.Drawing.Size(476, 53);
            this.lMostrarTecnico.TabIndex = 1;
            this.lMostrarTecnico.Text = "NOMBRE DEL TÉCNICO";
            this.lMostrarTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTecnicoAsignado
            // 
            this.lTecnicoAsignado.AutoSize = true;
            this.lTecnicoAsignado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lTecnicoAsignado.Location = new System.Drawing.Point(39, 106);
            this.lTecnicoAsignado.Name = "lTecnicoAsignado";
            this.lTecnicoAsignado.Size = new System.Drawing.Size(54, 53);
            this.lTecnicoAsignado.TabIndex = 1;
            this.lTecnicoAsignado.Text = "Técnico Asignado:";
            this.lTecnicoAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCliente
            // 
            this.lCliente.AutoSize = true;
            this.lCliente.Dock = System.Windows.Forms.DockStyle.Right;
            this.lCliente.Location = new System.Drawing.Point(51, 0);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(42, 53);
            this.lCliente.TabIndex = 35;
            this.lCliente.Text = "Cliente:";
            this.lCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.bAceptar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bCancelar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(99, 321);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 50);
            this.tableLayoutPanel2.TabIndex = 32;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel2_Paint);
            // 
            // bAceptar
            // 
            this.bAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAceptar.Location = new System.Drawing.Point(3, 3);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(232, 44);
            this.bAceptar.TabIndex = 0;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(241, 3);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(232, 44);
            this.bCancelar.TabIndex = 1;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lMostrarCaso
            // 
            this.lMostrarCaso.AutoSize = true;
            this.lMostrarCaso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMostrarCaso.Location = new System.Drawing.Point(99, 53);
            this.lMostrarCaso.Name = "lMostrarCaso";
            this.lMostrarCaso.Size = new System.Drawing.Size(476, 53);
            this.lMostrarCaso.TabIndex = 38;
            this.lMostrarCaso.Text = "NÚMERO DE CASO";
            this.lMostrarCaso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lVendendor
            // 
            this.lVendendor.AutoSize = true;
            this.lVendendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVendendor.Location = new System.Drawing.Point(3, 159);
            this.lVendendor.Name = "lVendendor";
            this.lVendendor.Size = new System.Drawing.Size(90, 53);
            this.lVendendor.TabIndex = 39;
            this.lVendendor.Text = "Vendedor:";
            this.lVendendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMostrarVendedor
            // 
            this.lMostrarVendedor.AutoSize = true;
            this.lMostrarVendedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMostrarVendedor.Location = new System.Drawing.Point(99, 159);
            this.lMostrarVendedor.Name = "lMostrarVendedor";
            this.lMostrarVendedor.Size = new System.Drawing.Size(476, 53);
            this.lMostrarVendedor.TabIndex = 40;
            this.lMostrarVendedor.Text = "NOMBRE DEL VENDEDOR";
            this.lMostrarVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lMostrarVendedor.Click += new System.EventHandler(this.Label6_Click);
            // 
            // lImagen
            // 
            this.lImagen.AutoSize = true;
            this.lImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lImagen.Location = new System.Drawing.Point(3, 265);
            this.lImagen.Name = "lImagen";
            this.lImagen.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lImagen.Size = new System.Drawing.Size(90, 53);
            this.lImagen.TabIndex = 42;
            this.lImagen.Text = "Imagen:";
            this.lImagen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.30252F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.69748F));
            this.tableLayoutPanel3.Controls.Add(this.bSeleccionar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelImagen, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(99, 268);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(476, 47);
            this.tableLayoutPanel3.TabIndex = 43;
            // 
            // bSeleccionar
            // 
            this.bSeleccionar.Dock = System.Windows.Forms.DockStyle.Top;
            this.bSeleccionar.Location = new System.Drawing.Point(3, 3);
            this.bSeleccionar.Name = "bSeleccionar";
            this.bSeleccionar.Size = new System.Drawing.Size(142, 23);
            this.bSeleccionar.TabIndex = 0;
            this.bSeleccionar.Text = "Seleccionar Imagen";
            this.bSeleccionar.UseVisualStyleBackColor = true;
            this.bSeleccionar.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // labelImagen
            // 
            this.labelImagen.AutoSize = true;
            this.labelImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelImagen.Location = new System.Drawing.Point(151, 0);
            this.labelImagen.Name = "labelImagen";
            this.labelImagen.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelImagen.Size = new System.Drawing.Size(322, 47);
            this.labelImagen.TabIndex = 1;
            this.labelImagen.Text = "IMAGEN SIN SELECCIONAR";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RegistroDeInformeFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(643, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "RegistroDeInformeFinal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Informe Final";
            this.Load += new System.EventHandler(this.CambioDeDatosCaso_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbInformeFinal;
        private System.Windows.Forms.Label lInformeFinal;
        private System.Windows.Forms.Label lTecnicoAsignado;
        private System.Windows.Forms.Label lMostrarTecnico;
        private System.Windows.Forms.Label lCliente;
        private System.Windows.Forms.Label lNumCaso;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label lMostrarCaso;
        private System.Windows.Forms.Label lVendendor;
        private System.Windows.Forms.Label lMostrarVendedor;
        private System.Windows.Forms.Label lMostrarCliente;
        private System.Windows.Forms.Label lImagen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button bSeleccionar;
        private System.Windows.Forms.Label labelImagen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}