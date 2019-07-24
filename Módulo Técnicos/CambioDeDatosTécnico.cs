using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace proyectoPantalla
{
    public partial class CambioDeDatosTécnico : Form
    {
        int ippersona;
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)@\\w+([-.]\\w+)\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public CambioDeDatosTécnico(String cedula)
        {
            InitializeComponent();
            consultaTecnico(cedula);
            MessageBox.Show(cedula);
        }
        private void consultaTecnico(String cedula)
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
            SqlCommand command, command2;
            SqlDataReader lector, lector2;
            conexion.Open();
            command = new SqlCommand("select PERSONA.IDPERSONA, NOMBRE, IDENTIFICACION, CORREO, SECTOR, ALCANCE from TECNICO, PERSONA where TECNICO.IDPERSONA = PERSONA.IDPERSONA and PERSONA.IDENTIFICACION = '" + cedula + "'", conexion);
            lector = command.ExecuteReader();
            while (lector.Read())
            {
                tbNombre.Text = lector.GetValue(1).ToString();
                tbCorreo.Text = lector.GetValue(3).ToString();
                tbCedula.Text = lector.GetValue(2).ToString();
                tbSector.Text = lector.GetValue(4).ToString();
                tbAlcance.Text = lector.GetValue(5).ToString();
                ippersona = Int32.Parse(lector.GetValue(0).ToString());
            }
            lector.Close();
            command2 = new SqlCommand("select PERSONA.IDPERSONA, TELEFONO, TIPO from TELEFONO, PERSONA where TELEFONO.IDPERSONA=PERSONA.IDPERSONA and PERSONA.IDPERSONA = " + ippersona + " order by persona.IDPERSONA", conexion);
            lector2 = command2.ExecuteReader();
            while (lector2.Read())
            {
                if (lector2.GetValue(2).ToString().Equals("CONVENCIONAL1"))
                {
                    tbTelefono1.Text = lector2.GetValue(1).ToString();
                }
                else if (lector2.GetValue(2).ToString().Equals("CONVENCIONAL2"))
                {
                    tbTelefono2.Text = lector2.GetValue(1).ToString();
                }
                else if (lector2.GetValue(2).ToString().Equals("CELULAR1"))
                {
                    tbCelular1.Text = lector2.GetValue(1).ToString();
                }
                else if (lector2.GetValue(2).ToString().Equals("CELULAR2"))
                {
                    tbCelular2.Text = lector2.GetValue(1).ToString();
                }
                lector2.GetValue(1).ToString();
            }
            lector.Close();
            conexion.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
                conexion.Open();
                SqlCommand command;
                command = new SqlCommand("update PERSONA set CORREO = '' where IDPERSONA = " + ippersona + "; " +
                    "update TECNICO set SECTOR = '" + tbSector.Text + "'," +
                    " ALCANCE = '" + tbAlcance.Text + "' " +
                    "where IDPERSONA = " + ippersona + ";", conexion);
                command.ExecuteNonQuery();


                SqlCommand command2 = new SqlCommand("SP_MODIFICACION_TELFONOS", conexion);
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@convencional1", tbTelefono1.Text);
                command2.Parameters.AddWithValue("@convencional2", tbTelefono2.Text);
                command2.Parameters.AddWithValue("@movil1", tbCelular1.Text);
                command2.Parameters.AddWithValue("@movil2", tbCelular2.Text);
                command2.Parameters.AddWithValue("@idpersona", ippersona);
                command2.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Técnico Modificado Correctamente", "Técnico Modificado");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base:" + ex);
            }
        }

        private void CambioDeDatosTécnico_Load(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = ComprobarFormatoEmail(tbCorreo.Text);
            if (flag)
            {
                Console.WriteLine("CORREO BUENO");
                tbCorreo.ForeColor = Color.Green;

            }
            else
            {
                tbCorreo.ForeColor = Color.Red;
            }

        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (ComprobarFormatoEmail(tbCorreo.Text))
            {
                errorProvider1.SetError(tbCorreo, null);
            }
            else
            {
                errorProvider1.SetError(tbCorreo, "Ingrese correo electrónico correctamente");
            }
        }
    }
}
