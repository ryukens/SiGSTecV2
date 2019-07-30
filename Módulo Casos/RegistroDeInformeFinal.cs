using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class RegistroDeInformeFinal : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");

        public RegistroDeInformeFinal( String idcaso, String nombreCliente, String numeroCaso, String nombreTecnico, String nombreVendedor, CierreDeCaso cierreDeCaso)
        {
            InitializeComponent();
            this.idcaso = idcaso;
            this.nombreCliente = nombreCliente;
            this.numeroCaso = numeroCaso;
            this.nombreCliente = nombreTecnico;
            this.nombreVendedor = nombreVendedor;
            this.cierreDeCaso = cierreDeCaso;
            
            lMostrarCliente.Text = nombreCliente;
            lMostrarCaso.Text = numeroCaso;
            lMostrarTecnico.Text = nombreTecnico;
            lMostrarVendedor.Text = nombreVendedor;

        }

        String idcaso;
        String nombreCliente;
        String numeroCaso;
        String nombreTecnico;
        String nombreVendedor;
        CierreDeCaso cierreDeCaso;

        OpenFileDialog openFileD = new OpenFileDialog();


        private void Button2_Click(object sender, EventArgs e)
        {
            tbInformeFinal.ResetText();
            labelImagen.Text = "IMAGEN SIN SELECCIONAR";
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (labelImagen.Text == "IMAGEN SIN SELECCIONAR")
            {
                MessageBox.Show("Debe seleccionar una imagen");

            }
            else if( tbInformeFinal.Text.Trim()=="")
            {
                MessageBox.Show("Debe ingresar informe final");
                
            }
            else if (MessageBox.Show("¿Está seguro que desea guardar esta información?", "Registrar Informe Final", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conexion.Open();

                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_INFORME_FINAL_PATH", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@IDCASO", idcaso);
                comando1.Parameters.AddWithValue("@INFORME_FINAL", tbInformeFinal.Text);
                comando1.Parameters.AddWithValue("@PARTE_PATH", labelImagen.Text);

                comando1.ExecuteNonQuery();
                conexion.Close();

                string direccion = @"..\..\Fotos\Parte";
                System.IO.File.SetAttributes(direccion, System.IO.FileAttributes.Normal);
                string destino = System.IO.Path.Combine(direccion, System.IO.Path.GetFileName(openFileD.FileName));
                System.IO.File.Copy(openFileD.FileName, destino, true);


                MessageBox.Show("Informe Final Registrado Correctamente", "Informe Final Registrado");

                cierreDeCaso.muestraCasos();

                this.Dispose();

            }

            
            

           
        }

        

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

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

        private void LMostrarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
