namespace proyectoPantalla
{
    partial class RegistroDeUsuario
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lTipo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bCrear = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.lCedula = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbCedula = new System.Windows.Forms.TextBox();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);

            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 393);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lTipo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbTipo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lNombre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lCedula, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbNombre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCedula, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbCorreo, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 393);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint_1);
            // 
            // lTipo
            // 
            this.lTipo.AutoSize = true;
            this.lTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTipo.Location = new System.Drawing.Point(3, 234);
            this.lTipo.Name = "lTipo";
            this.lTipo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lTipo.Size = new System.Drawing.Size(80, 78);
            this.lTipo.TabIndex = 129;
            this.lTipo.Text = "Tipo:";
            this.lTipo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.bCancelar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.bCrear, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(119, 388);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 75);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // bCancelar
            // 
            this.bCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCancelar.Location = new System.Drawing.Point(289, 4);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(208, 69);
            this.bCancelar.TabIndex = 3;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            // 
            // bCrear
            // 
            this.bCrear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCrear.Location = new System.Drawing.Point(4, 4);
            this.bCrear.Margin = new System.Windows.Forms.Padding(4);
            this.bCrear.Name = "bCrear";
            this.bCrear.Size = new System.Drawing.Size(208, 69);
            this.bCrear.TabIndex = 4;
            this.bCrear.Text = "Crear";
            this.bCrear.UseVisualStyleBackColor = true;
            this.bCrear.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Empleado De Mesa De Servicios",
            "Empleado De Ventas",
            "Empleado De Compras",
            "Bodeguero"});
            this.cbTipo.Location = new System.Drawing.Point(119, 292);
            this.cbTipo.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(428, 21);
            this.cbTipo.TabIndex = 20;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.CbTipo_SelectedIndexChanged);
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lNombre.Location = new System.Drawing.Point(3, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lNombre.Size = new System.Drawing.Size(80, 78);
            this.lNombre.TabIndex = 21;
            this.lNombre.Text = "Nombre:";
            this.lNombre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lCedula
            // 
            this.lCedula.AutoSize = true;
            this.lCedula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCedula.Location = new System.Drawing.Point(3, 78);
            this.lCedula.Name = "lCedula";
            this.lCedula.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lCedula.Size = new System.Drawing.Size(80, 78);
            this.lCedula.TabIndex = 22;
            this.lCedula.Text = "Cédula de ciudadanía:";
            this.lCedula.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(80, 78);
            this.label6.TabIndex = 23;
            this.label6.Text = "Correo Electrónico:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbNombre
            // 
            this.tbNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNombre.Location = new System.Drawing.Point(119, 4);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(428, 20);
            this.tbNombre.TabIndex = 128;
            this.tbNombre.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            this.tbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox3_KeyPress);
            // 
            // tbCedula
            // 
            this.tbCedula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCedula.Location = new System.Drawing.Point(119, 100);
            this.tbCedula.Margin = new System.Windows.Forms.Padding(4);
            this.tbCedula.MaxLength = 10;
            this.tbCedula.Name = "tbCedula";
            this.tbCedula.Size = new System.Drawing.Size(428, 20);
            this.tbCedula.TabIndex = 25;
            this.tbCedula.TextChanged += new System.EventHandler(this.TbCedula_TextChanged);
            this.tbCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbCedula_KeyPress);
            this.tbCedula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCedula_KeyUp);
            // 
            // tbCorreo
            // 
            this.tbCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCorreo.Location = new System.Drawing.Point(119, 196);
            this.tbCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.tbCorreo.MaxLength = 64;
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(428, 20);
            this.tbCorreo.TabIndex = 26;
            this.tbCorreo.TextChanged += new System.EventHandler(this.TbCorreo_TextChanged);
            this.tbCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCorreo_KeyUp);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegistroDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistroDeUsuario";
            this.Size = new System.Drawing.Size(579, 393);
            this.Load += new System.EventHandler(this.NuevoUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bCrear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label lCedula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbCedula;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Label lTipo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
