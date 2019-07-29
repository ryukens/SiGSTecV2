namespace proyectoPantalla.Módulo_Administración
{
    partial class RecuperaciónContraseña
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDarDeAlta = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bRecuperar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.lBuscar = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarDeAlta)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lBuscar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 511);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.cbBuscar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbBuscar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(119, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(547, 39);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbBuscar
            // 
            this.cbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuscar.FormattingEnabled = true;
            this.cbBuscar.Items.AddRange(new object[] {
            "Nombre",
            "Cédula de Ciudadanía"});
            this.cbBuscar.Location = new System.Drawing.Point(7, 6);
            this.cbBuscar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbBuscar.Name = "cbBuscar";
            this.cbBuscar.Size = new System.Drawing.Size(177, 24);
            this.cbBuscar.TabIndex = 0;
            // 
            // tbBuscar
            // 
            this.tbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBuscar.Location = new System.Drawing.Point(198, 6);
            this.tbBuscar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(342, 22);
            this.tbBuscar.TabIndex = 1;
            this.tbBuscar.TextChanged += new System.EventHandler(this.TbBuscar_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDarDeAlta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(119, 57);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 396);
            this.panel3.TabIndex = 4;
            // 
            // dgvDarDeAlta
            // 
            this.dgvDarDeAlta.AllowUserToAddRows = false;
            this.dgvDarDeAlta.AllowUserToDeleteRows = false;
            this.dgvDarDeAlta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarDeAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDarDeAlta.Location = new System.Drawing.Point(0, 0);
            this.dgvDarDeAlta.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dgvDarDeAlta.MultiSelect = false;
            this.dgvDarDeAlta.Name = "dgvDarDeAlta";
            this.dgvDarDeAlta.ReadOnly = true;
            this.dgvDarDeAlta.RowHeadersWidth = 51;
            this.dgvDarDeAlta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDarDeAlta.Size = new System.Drawing.Size(547, 396);
            this.dgvDarDeAlta.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.bRecuperar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bCancelar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(119, 465);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(547, 40);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // bRecuperar
            // 
            this.bRecuperar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bRecuperar.Location = new System.Drawing.Point(7, 6);
            this.bRecuperar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bRecuperar.Name = "bRecuperar";
            this.bRecuperar.Size = new System.Drawing.Size(259, 28);
            this.bRecuperar.TabIndex = 1;
            this.bRecuperar.Text = "Recuperar Contraseña";
            this.bRecuperar.UseVisualStyleBackColor = true;
            this.bRecuperar.Click += new System.EventHandler(this.BRecuperar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(278, 5);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(5);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(264, 30);
            this.bCancelar.TabIndex = 2;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // lBuscar
            // 
            this.lBuscar.AutoSize = true;
            this.lBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBuscar.Location = new System.Drawing.Point(4, 0);
            this.lBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBuscar.Name = "lBuscar";
            this.lBuscar.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lBuscar.Size = new System.Drawing.Size(104, 51);
            this.lBuscar.TabIndex = 2;
            this.lBuscar.Text = "Buscar por:";
            this.lBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RecuperaciónContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecuperaciónContraseña";
            this.Size = new System.Drawing.Size(748, 511);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarDeAlta)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDarDeAlta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bRecuperar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label lBuscar;
    }
}
