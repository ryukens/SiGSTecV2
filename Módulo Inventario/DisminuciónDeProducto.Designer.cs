﻿namespace proyectoPantalla
{
    partial class DisminuciónDeProducto
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
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.dgvAsignar = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDisminuir = new System.Windows.Forms.DataGridView();
            this.lBuscar = new System.Windows.Forms.Label();
            this.tbFactura = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.bAsignar = new System.Windows.Forms.Button();
            this.bQuitar = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignar)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisminuir)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDisminuir, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.bAceptar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bCancelar, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lBuscar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFactura, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.55901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.44099F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 478);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // bAceptar
            // 
            this.bAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAceptar.Location = new System.Drawing.Point(105, 433);
            this.bAceptar.Margin = new System.Windows.Forms.Padding(5);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(340, 40);
            this.bAceptar.TabIndex = 18;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(555, 433);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(5);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(340, 40);
            this.bCancelar.TabIndex = 16;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.BCancelar_Click_1);
            // 
            // dgvAsignar
            // 
            this.dgvAsignar.AllowUserToAddRows = false;
            this.dgvAsignar.AllowUserToDeleteRows = false;
            this.dgvAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignar.Location = new System.Drawing.Point(0, 0);
            this.dgvAsignar.Margin = new System.Windows.Forms.Padding(5);
            this.dgvAsignar.MultiSelect = false;
            this.dgvAsignar.Name = "dgvAsignar";
            this.dgvAsignar.ReadOnly = true;
            this.dgvAsignar.RowHeadersVisible = false;
            this.dgvAsignar.RowHeadersWidth = 51;
            this.dgvAsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignar.Size = new System.Drawing.Size(340, 373);
            this.dgvAsignar.TabIndex = 13;
            this.dgvAsignar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAsignar_CellContentClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.cbBuscar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbBuscar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(105, 5);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(340, 35);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // cbBuscar
            // 
            this.cbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuscar.FormattingEnabled = true;
            this.cbBuscar.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.cbBuscar.Location = new System.Drawing.Point(5, 5);
            this.cbBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.cbBuscar.Name = "cbBuscar";
            this.cbBuscar.Size = new System.Drawing.Size(92, 24);
            this.cbBuscar.TabIndex = 0;
            // 
            // tbBuscar
            // 
            this.tbBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBuscar.Location = new System.Drawing.Point(107, 5);
            this.tbBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(228, 22);
            this.tbBuscar.TabIndex = 1;
            this.tbBuscar.TextChanged += new System.EventHandler(this.TbBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(68, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Buscar por:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAsignar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(105, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 373);
            this.panel3.TabIndex = 4;
            // 
            // dgvDisminuir
            // 
            this.dgvDisminuir.AllowUserToAddRows = false;
            this.dgvDisminuir.AllowUserToDeleteRows = false;
            this.dgvDisminuir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisminuir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisminuir.Location = new System.Drawing.Point(555, 50);
            this.dgvDisminuir.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDisminuir.MultiSelect = false;
            this.dgvDisminuir.Name = "dgvDisminuir";
            this.dgvDisminuir.ReadOnly = true;
            this.dgvDisminuir.RowHeadersVisible = false;
            this.dgvDisminuir.RowHeadersWidth = 51;
            this.dgvDisminuir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisminuir.Size = new System.Drawing.Size(340, 373);
            this.dgvDisminuir.TabIndex = 0;
            // 
            // lBuscar
            // 
            this.lBuscar.AutoSize = true;
            this.lBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lBuscar.Location = new System.Drawing.Point(454, 0);
            this.lBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBuscar.Name = "lBuscar";
            this.lBuscar.Size = new System.Drawing.Size(92, 45);
            this.lBuscar.TabIndex = 8;
            this.lBuscar.Text = "Nº Orden de entrega:";
            this.lBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lBuscar.UseMnemonic = false;
            // 
            // tbFactura
            // 
            this.tbFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFactura.Location = new System.Drawing.Point(555, 5);
            this.tbFactura.Margin = new System.Windows.Forms.Padding(5);
            this.tbFactura.MaxLength = 16;
            this.tbFactura.Name = "tbFactura";
            this.tbFactura.Size = new System.Drawing.Size(340, 22);
            this.tbFactura.TabIndex = 1;
            this.tbFactura.TextChanged += new System.EventHandler(this.TbFactura_TextChanged);
            this.tbFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbFactura_KeyPress);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.bAsignar, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.bQuitar, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(455, 50);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(90, 373);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // bAsignar
            // 
            this.bAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bAsignar.Location = new System.Drawing.Point(5, 79);
            this.bAsignar.Margin = new System.Windows.Forms.Padding(5);
            this.bAsignar.Name = "bAsignar";
            this.bAsignar.Size = new System.Drawing.Size(80, 64);
            this.bAsignar.TabIndex = 15;
            this.bAsignar.Text = "Asignar\r\n--------->";
            this.bAsignar.UseVisualStyleBackColor = true;
            this.bAsignar.Click += new System.EventHandler(this.BAsignar_Click);
            // 
            // bQuitar
            // 
            this.bQuitar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bQuitar.Location = new System.Drawing.Point(5, 227);
            this.bQuitar.Margin = new System.Windows.Forms.Padding(5);
            this.bQuitar.Name = "bQuitar";
            this.bQuitar.Size = new System.Drawing.Size(80, 64);
            this.bQuitar.TabIndex = 16;
            this.bQuitar.Text = "Quitar\r\n<---------";
            this.bQuitar.UseVisualStyleBackColor = true;
            this.bQuitar.Click += new System.EventHandler(this.BQuitar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.nudCantidad, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 153);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(80, 64);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCantidad.Location = new System.Drawing.Point(5, 26);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(5);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.ReadOnly = true;
            this.nudCantidad.Size = new System.Drawing.Size(70, 22);
            this.nudCantidad.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DisminuciónDeProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DisminuciónDeProducto";
            this.Size = new System.Drawing.Size(1000, 478);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignar)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisminuir)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDisminuir;
        private System.Windows.Forms.Label lBuscar;
        private System.Windows.Forms.TextBox tbFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.DataGridView dgvAsignar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bAsignar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bQuitar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
    }
}
