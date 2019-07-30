namespace proyectoPantalla
{
    partial class GeneraciónDeInforme
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lFechaFinal = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.lFechaInicio = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.panel28, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel26, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(832, 480);
            this.tableLayoutPanel2.TabIndex = 3;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel2_Paint);
            // 
            // panel28
            // 
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(793, 436);
            this.panel28.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(35, 40);
            this.panel28.TabIndex = 14;
            // 
            // panel26
            // 
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(4, 436);
            this.panel26.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(33, 40);
            this.panel26.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bCancelar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(45, 436);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 40);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(374, 4);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(362, 32);
            this.bCancelar.TabIndex = 1;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lFechaFinal, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.bAceptar, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lFechaInicio, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtFechaInicio, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtFechaFinal, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(45, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(740, 40);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // lFechaFinal
            // 
            this.lFechaFinal.AutoSize = true;
            this.lFechaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFechaFinal.Location = new System.Drawing.Point(300, 0);
            this.lFechaFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaFinal.Name = "lFechaFinal";
            this.lFechaFinal.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lFechaFinal.Size = new System.Drawing.Size(140, 40);
            this.lFechaFinal.TabIndex = 1;
            this.lFechaFinal.Text = "Fecha Final:";
            this.lFechaFinal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bAceptar
            // 
            this.bAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAceptar.Location = new System.Drawing.Point(596, 4);
            this.bAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(140, 32);
            this.bAceptar.TabIndex = 1;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.AutoSize = true;
            this.lFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFechaInicio.Location = new System.Drawing.Point(4, 0);
            this.lFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lFechaInicio.Size = new System.Drawing.Size(140, 40);
            this.lFechaInicio.TabIndex = 1;
            this.lFechaInicio.Text = "Fecha Inicial:";
            this.lFechaInicio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "yyyy-MM-dd";
            this.dtFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(152, 4);
            this.dtFechaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(140, 22);
            this.dtFechaInicio.TabIndex = 16;
            this.dtFechaInicio.Value = new System.DateTime(2019, 7, 6, 21, 49, 0, 0);
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.CustomFormat = "yyyy-MM-dd";
            this.dtFechaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFinal.Location = new System.Drawing.Point(448, 4);
            this.dtFechaFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(140, 22);
            this.dtFechaFinal.TabIndex = 17;
            this.dtFechaFinal.Value = new System.DateTime(2019, 7, 21, 12, 14, 0, 0);
            this.dtFechaFinal.ValueChanged += new System.EventHandler(this.DtFechaFinal_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(45, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(740, 376);
            this.dataGridView1.TabIndex = 19;
            // 
            // GeneraciónDeInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GeneraciónDeInforme";
            this.Size = new System.Drawing.Size(832, 480);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Label lFechaFinal;
        private System.Windows.Forms.Label lFechaInicio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
