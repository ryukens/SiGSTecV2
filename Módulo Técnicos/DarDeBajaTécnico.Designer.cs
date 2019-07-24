namespace proyectoPantalla
{
    partial class DarDeBajaTécnico
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.lBuscar = new System.Windows.Forms.Label();
            this.dgvEliminar = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminar)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.lBuscar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvEliminar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 501);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.cbBuscar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbBuscar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(144, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(673, 38);
            this.tableLayoutPanel3.TabIndex = 4;
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
            this.cbBuscar.Size = new System.Drawing.Size(221, 24);
            this.cbBuscar.TabIndex = 0;
            this.cbBuscar.SelectedIndexChanged += new System.EventHandler(this.CbBuscar_SelectedIndexChanged);
            // 
            // tbBuscar
            // 
            this.tbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBuscar.Location = new System.Drawing.Point(242, 6);
            this.tbBuscar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(424, 22);
            this.tbBuscar.TabIndex = 1;
            this.tbBuscar.TextChanged += new System.EventHandler(this.TbBuscar_TextChanged);
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
            this.lBuscar.Size = new System.Drawing.Size(129, 50);
            this.lBuscar.TabIndex = 0;
            this.lBuscar.Text = "Buscar por:";
            this.lBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvEliminar
            // 
            this.dgvEliminar.AllowUserToAddRows = false;
            this.dgvEliminar.AllowUserToDeleteRows = false;
            this.dgvEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEliminar.Location = new System.Drawing.Point(144, 56);
            this.dgvEliminar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dgvEliminar.MultiSelect = false;
            this.dgvEliminar.Name = "dgvEliminar";
            this.dgvEliminar.ReadOnly = true;
            this.dgvEliminar.RowHeadersWidth = 51;
            this.dgvEliminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEliminar.Size = new System.Drawing.Size(673, 388);
            this.dgvEliminar.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.bEliminar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bCancelar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(144, 456);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 39);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // bEliminar
            // 
            this.bEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bEliminar.Location = new System.Drawing.Point(7, 6);
            this.bEliminar.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(322, 27);
            this.bEliminar.TabIndex = 0;
            this.bEliminar.Text = "Dar de Baja";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(341, 5);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(327, 29);
            this.bCancelar.TabIndex = 1;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // DarDeBajaTécnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "DarDeBajaTécnico";
            this.Size = new System.Drawing.Size(916, 501);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminar)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lBuscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.DataGridView dgvEliminar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Button bCancelar;
    }
}
