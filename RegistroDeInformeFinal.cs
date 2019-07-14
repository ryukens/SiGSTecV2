using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class RegistroDeInformeFinal : Form
    {
        public RegistroDeInformeFinal()
        {
            InitializeComponent();
            
        }

        OpenFileDialog openFileD = new OpenFileDialog();

        private void CambioDeDatosCaso_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tbInformeFinal.ResetText();
            labelImagen.Text = "IMAGEN SIN SELECCIONAR";
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea guardar esta información?", "Registrar Informe Final", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                MessageBox.Show("Informe Final Registrado Correctamente", "Informe Final Registrado");
            }

            string direccion = @"..\..\Fotos\Parte";
            System.IO.File.SetAttributes(direccion, System.IO.FileAttributes.Normal);
            string destino = System.IO.Path.Combine(direccion, System.IO.Path.GetFileName(openFileD.FileName));
            System.IO.File.Copy(openFileD.FileName, destino, true);

            this.Dispose();
            
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AsignaciónDeProductos asignaciónDeProductos = new AsignaciónDeProductos();
            asignaciónDeProductos.Show();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            openFileD.Filter = "All Files|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (openFileD.ShowDialog() == DialogResult.OK)
            {
                labelImagen.Text = openFileD.SafeFileName;
            }
            
        }

        
    }
}
