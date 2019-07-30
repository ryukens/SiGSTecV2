using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyectoPantalla
{
    public partial class RegistroDeCliente : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
        TabControl tabControl;
        TabPage tabInicio;
        //flag = false cuando hay campo vacio
        bool flagCedula = false;
        bool flagNombre = false;
        bool flagCuenta = true;
        bool flagCorreo = false;
        bool flagNContacto = false;
        bool flagDescripcion = false;
        bool flagTelefonos = false;
        bool flagTelefonos2 = false;
        bool flagMoviles = false;
        bool flagMoviles2 = false;

        bool errorTelefonos = false;
        bool errorTelefonos2 = false;
        bool errorMoviles = false;
        bool errorMoviles2 = false;
        bool errorCorreo = false;

        int errorCedula = -1;

        public RegistroDeCliente(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            cbSLA.SelectedIndex = 0;
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
            tbTelefono2.Enabled = false;
            tbCelular2.Enabled = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (validarEntrada())
            {



                conexion.Open();
                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_CLIENTE", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@nombre", tbNombre.Text);
                comando1.Parameters.AddWithValue("@correo", tbCorreo.Text);
                comando1.Parameters.AddWithValue("@identificacion", tbCedula.Text);
                comando1.Parameters.AddWithValue("@nombre_contacto", tbNombreCont.Text);
                comando1.Parameters.AddWithValue("@descripcion_contacto", tbDescripcion.Text);
                comando1.Parameters.AddWithValue("@sla", cbSLA.SelectedItem.ToString());
                comando1.Parameters.AddWithValue("@cuenta", tbCuenta.Text);


                if (rbAcordado.Checked)
                {
                    comando1.Parameters.AddWithValue("@tipo_pago", rbAcordado.Text);
                }
                else
                {
                    comando1.Parameters.AddWithValue("@tipo_pago", rbDefinido.Text);
                }
                if (rbEmpresa.Checked)
                {
                    comando1.Parameters.AddWithValue("@tipo", rbEmpresa.Text);
                }
                else
                {
                    comando1.Parameters.AddWithValue("@tipo", rbPersona.Text);
                }

                comando1.ExecuteNonQuery();


                if (!tbTelefono1.Text.Trim().Equals(""))
                {

                    SqlCommand comando3 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL1", conexion);
                    comando3.CommandType = CommandType.StoredProcedure;
                    comando3.Parameters.AddWithValue("@telefono", tbTelefono1.Text);
                    comando3.ExecuteNonQuery();
                }

                if (!tbTelefono2.Text.Trim().Equals(""))
                {
                    SqlCommand comando4 = new SqlCommand("SP_REGISTRO_TELEFONO_CONVENCIONAL2", conexion);
                    comando4.CommandType = CommandType.StoredProcedure;
                    comando4.Parameters.AddWithValue("@telefono", tbTelefono2.Text);
                    comando4.ExecuteNonQuery();
                }

                if (!tbCelular1.Text.Trim().Equals(""))
                {
                    SqlCommand comando5 = new SqlCommand("SP_REGISTRO_CELULAR1", conexion);
                    comando5.CommandType = CommandType.StoredProcedure;
                    comando5.Parameters.AddWithValue("@telefono", tbCelular1.Text);
                    comando5.ExecuteNonQuery();
                }
                if (!tbCelular2.Text.Trim().Equals(""))
                {
                    SqlCommand comando6 = new SqlCommand("SP_REGISTRO_CELULAR2", conexion);
                    comando6.CommandType = CommandType.StoredProcedure;
                    comando6.Parameters.AddWithValue("@telefono", tbCelular2.Text);
                    comando6.ExecuteNonQuery();
                }

                conexion.Close();
                MessageBox.Show("Cliente Registrado Correctamente", "Cliente Registrado");
                limpiarCampos();
            }
        }


        private void RbPersona_CheckedChanged(object sender, EventArgs e)
        {
            tbCuenta.Text = "N/A";
            tbCedula.MaxLength = 10;
            tbCedula.ResetText();
            flagCuenta = true;
        }

        private void RbEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            tbCuenta.Enabled = rbEmpresa.Checked;
            tbCuenta.Text = "";
            tbCedula.MaxLength = 13;
            tbCedula.ResetText();
            flagCuenta = false;

        }

        private void TbCedula_TextChanged(object sender, EventArgs e)
        {


            if (tbCedula.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCedula, null);
                flagCedula = false;

            }

            else
            {
                flagCedula = true;

                if (rbPersona.Checked)
                {
                    if (Validaciones.VerificaCedula(tbCedula.Text))
                    {

                        int r = Validaciones.verificarCedulaRepetida(tbCedula, conexion);

                        if (r != 0)
                        {
                            tbCedula.ForeColor = Color.Red;
                            errorProvider1.SetError(tbCedula, "Cédula de ciudadanía ya registrada");
                            errorCedula = 1;

                        }
                        else
                        {
                            errorProvider1.SetError(tbCedula, null);
                            tbCedula.ForeColor = Color.Green;
                            errorCedula = 0;

                        }

                    }
                    else
                    {
                        errorProvider1.SetError(tbCedula, "Cédula de ciudadanía incorrecta");
                        tbCedula.ForeColor = Color.Red;
                        errorCedula = 2;


                    }
                }
                else
                {
                    if (Validaciones.RucPersonaNatural(tbCedula.Text))
                    {

                        int r = Validaciones.verificarCedulaRepetida(tbCedula, conexion);

                        if (r != 0)
                        {
                            tbCedula.ForeColor = Color.Red;
                            errorProvider1.SetError(tbCedula, "RUC ya registrado");
                            errorCedula = 1;

                        }
                        else
                        {
                            errorProvider1.SetError(tbCedula, null);
                            tbCedula.ForeColor = Color.Green;
                            errorCedula = 0;

                        }

                    }
                    else
                    {
                        errorProvider1.SetError(tbCedula, "RUC incorrecto");
                        tbCedula.ForeColor = Color.Red;
                        errorCedula = 2;


                    }
                }

            }
        }

        public bool ValidarCamposVacios()
        {
            bool flag = true;
            List<TextBox> lista = GenerarLista();
            foreach (TextBox text in lista)
            {
                if (text.Text.Equals(""))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public List<TextBox> GenerarLista()
        {
            var al = new List<TextBox>();
            al.Add(tbNombre);
            al.Add(tbCuenta);
            al.Add(tbCedula);
            al.Add(tbCorreo);
            al.Add(tbCelular1);
            al.Add(tbTelefono1);
            al.Add(tbNombreCont);
            al.Add(tbDescripcion);
            //int tam = al.Count;
            return al;
        }

        private void TbCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TbCorreo_TextChanged(object sender, EventArgs e)
        {
            if (tbCorreo.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCorreo, null);
                flagCorreo = false;

            }
            else
            {
                flagCorreo = true;
                if (Validaciones.ComprobarFormatoEmail(tbCorreo.Text))
                {
                    errorProvider1.SetError(tbCorreo, null);
                    tbCorreo.ForeColor = Color.Green;
                    errorCorreo = false;


                }
                else
                {
                    errorProvider1.SetError(tbCorreo, "Ingrese un correo electrónico correcto");
                    errorCorreo = true;
                    tbCorreo.ForeColor = Color.Red;
                }
            }
        }

        private void TbCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            /*bool flag = Validaciones.ComprobarFormatoEmail(tbCorreo.Text);
            if (flag)
            {
                tbCorreo.ForeColor = Color.Green;
            }
            else
            {
                tbCorreo.ForeColor = Color.Red;
            }*/
        }

        private void TbTelf1_TextChanged(object sender, EventArgs e)
        {
            if (tbTelefono1.Text.Trim() == "")
            {
                errorProvider1.SetError(tbTelefono1, null);
                flagTelefonos = false;


            }
            else
            {
                flagTelefonos = true;
                if (Validaciones.formatoTelefono(tbTelefono1.Text))
                {
                    errorProvider1.SetError(tbTelefono1, null);
                    tbTelefono1.ForeColor = Color.Green;
                    tbTelefono2.Enabled = true;

                    errorTelefonos = false;


                }
                else
                {
                    errorProvider1.SetError(tbTelefono1, "El teléfono debe:\r\n" +
                        "- Iniciar con prefijo (02 - 07)\r\n" +
                        "- Tener 9 dígitos");
                    tbTelefono1.ForeColor = Color.Red;
                    tbTelefono2.Enabled = false;

                    errorTelefonos = true;




                }
            }
        }

        private void TbTelf1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbTelf2_TextChanged(object sender, EventArgs e)
        {

            if (tbTelefono2.Text.Trim() == "")

            {
                errorProvider1.SetError(tbTelefono2, null);
                errorTelefonos2 = false;


            }
            else
            {


                if (Validaciones.formatoTelefono(tbTelefono2.Text))


                {
                    errorProvider1.SetError(tbTelefono2, null);
                    tbTelefono2.ForeColor = Color.Green;

                    errorTelefonos2 = false;


                }
                else
                {
                    errorProvider1.SetError(tbTelefono2, "El teléfono debe:\r\n" +
                        "- Iniciar con prefijo (02 - 07)\r\n" +
                        "- Tener 9 dígitos");
                    tbTelefono2.ForeColor = Color.Red;

                    errorTelefonos2 = true;

                }
            }
        }

        private void TbTelf2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbCel1_TextChanged(object sender, EventArgs e)
        {
            if (tbCelular1.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCelular1, null);
                flagMoviles = false;
                errorMoviles = false;


            }
            else
            {

                flagMoviles = true;
                if (Validaciones.formatoCelular(tbCelular1.Text))
                {
                    errorProvider1.SetError(tbCelular1, null);
                    tbCelular1.ForeColor = Color.Green;
                    tbCelular2.Enabled = true;

                    errorMoviles = false;

                }
                else
                {
                    errorProvider1.SetError(tbCelular1, "El celular debe:\r\n" +
                        "- Iniciar con prefijo 09\r\n" +
                        "- Tener 10 dígitos");
                    tbCelular1.ForeColor = Color.Red;
                    tbCelular2.Enabled = false;

                    errorMoviles = true;
                }
            }
        }

        private void TbCel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //               MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TbCel2_TextChanged(object sender, EventArgs e)
        {
            if (tbCelular2.Text.Trim() == "")
            {
                errorProvider1.SetError(tbCelular2, null);




                tbCelular2.ForeColor = Color.Green;
                errorMoviles2 = false;


            }
            else
            {

                if (Validaciones.formatoCelular(tbCelular2.Text))
                {
                    errorProvider1.SetError(tbCelular2, null);
                    tbCelular2.ForeColor = Color.Green;

                    errorMoviles2 = false;


                }
                else
                {
                    errorProvider1.SetError(tbCelular2, "El celular debe:\r\n" +
                        "- Iniciar con prefijo 09\r\n" +
                        "- Tener 10 dígitos");
                    tbCelular2.ForeColor = Color.Red;

                    errorMoviles2 = true;

                }
            }
        }

        private void TbCel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void TbCedula_KeyUp(object sender, KeyEventArgs e)
        {
            /*  if (Validaciones.VerificaCedula(tbCedula.Text) || Validaciones.RucPersonaNatural(tbCedula.Text))
              {
                  errorProvider1.SetError(tbCedula, null);
                  tbCedula.ForeColor = Color.Green;

              }
              else
              {
                  errorProvider1.SetError(tbCedula, "Ingrese cédula o RUC correctamente");
                  tbCedula.ForeColor = Color.Red;
              }*/
        }

        public void limpiarCampos()
        {
            tbCedula.ResetText();
            tbCelular1.ResetText();
            tbCelular2.ResetText();
            tbCorreo.ResetText();
            tbCuenta.Text = "N/A";
            tbDescripcion.ResetText();
            tbNombre.ResetText();
            tbNombreCont.ResetText();
            tbTelefono1.ResetText();
            tbTelefono2.ResetText();
            tbTelefono2.Enabled = false;
            tbCelular2.Enabled = false;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabControl.SelectTab(tabInicio);
        }


        private void TbNombre_TextChanged(object sender, EventArgs e)
        {
            if (tbNombre.Text.Trim() == "")
            {
                flagNombre = false;

            }
            else
            {
                flagNombre = true;

            }
        }


        private void TbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbPersona.Checked)
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                if (!(char.IsLetter(e.KeyChar)) && !(Char.IsSeparator(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    // MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }

        private void TbCuenta_TextChanged(object sender, EventArgs e)
        {
            if (tbCuenta.Text.Trim() == "")
            {
                flagCuenta = false;

            }
            else
            {
                flagCuenta = true;

            }
        }

        private void TbNombreCont_TextChanged(object sender, EventArgs e)
        {
            if (tbNombreCont.Text.Trim() == "")
            {
                flagNContacto = false;

            }
            else
            {
                flagNContacto = true;

            }
        }

        public bool validarEntrada()
        {
            Console.WriteLine("ncontacto " + flagNContacto + "cedula " + flagCedula + "correo " + flagCorreo + "moviles " + flagMoviles + "nombre " + flagNombre + "descr " + flagDescripcion + "telefonos " + flagTelefonos + " Cuante" + flagCuenta );
            if (flagNContacto && flagCedula && flagCorreo && flagMoviles && flagNombre && flagDescripcion && flagTelefonos && flagCuenta)
            {
                if (errorCedula == 1)
                {
                    MessageBox.Show("Cédula de ciudadanía ya registrada", "Error");
                    return false;
                }
                else if (errorCedula == 2)
                {
                    MessageBox.Show("Cédula de ciudadanía incorrecta", "Error");
                    return false;
                }
                if (errorCorreo)
                {

                    MessageBox.Show("Correo electrónico incorrecto", "Error");
                    return false;
                }
                if (errorTelefonos)
                {
                    MessageBox.Show("Teléfono convencional incorrecto", "Error");
                    return false;
                }
                if (errorTelefonos2)
                {
                    MessageBox.Show("Teléfono convencional incorrecto", "Error");
                    return false;
                }
                if (errorMoviles)
                {
                    MessageBox.Show("Celular incorrecto", "Error");
                    return false;
                }
                if (errorMoviles2)
                {
                    MessageBox.Show("Celular incorrecto", "Error");
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Existen campos vacíos", "Campos Vacíos");
                return false;
            }
        }

        private void TbDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (tbDescripcion.Text.Trim() == "")
            {
                flagDescripcion = false;

            }
            else
            {
                flagDescripcion = true;

            }
        }

        private void TbNombre_TextChanged_1(object sender, EventArgs e)
        {
            if (tbNombre.Text.Trim() == "")
            {
                flagNombre = false;

            }
            else
            {
                flagNombre = true;

            }
        }
    }
}
