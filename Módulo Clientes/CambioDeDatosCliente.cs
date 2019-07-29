﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla
{
    public partial class CambioDeDatosCliente : Form
    {
        int ippersona;
        
        
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
        public CambioDeDatosCliente(String cedula)
        {
            InitializeComponent();
            consultaCliente(cedula);
        }

        private void consultaCliente(String cedula)
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
            SqlCommand command, command2;
            SqlDataReader lector, lector2;
            conexion.Open();
            command = new SqlCommand("select CLIENTE.IDPERSONA, NOMBRE, CORREO, IDENTIFICACION, NOMBRE_CONTACTO, DESCRIPCION_CONTACTO,SLA,CUENTA,TIPO_PAGO,TIPO from PERSONA, CLIENTE where PERSONA.IDPERSONA=CLIENTE.IDPERSONA AND PERSONA.IDENTIFICACION = '" + cedula + "';", conexion);
            lector = command.ExecuteReader();
            while (lector.Read())
            {
                tbNombre.Text = lector.GetValue(1).ToString();
                tbCorreo.Text = lector.GetValue(2).ToString(); ;
                tbCedula.Text = lector.GetValue(3).ToString(); ;
                tbNombreCont.Text = lector.GetValue(4).ToString(); ;
                tbDescripcion.Text = lector.GetValue(5).ToString(); ;
                cbSLA.Text = lector.GetValue(6).ToString(); ;
                tbCuenta.Text = lector.GetValue(7).ToString(); ;
                if (lector.GetValue(8).ToString().Equals("Acordado con cliente"))
                {
                    rbAcordado.Checked = true;
                }
                else
                {
                    rbDefinido.Checked = true;
                }
                if (lector.GetValue(9).ToString().Equals("Persona"))
                {
                    rbPersona.Checked = true;
                }
                else
                {
                    rbEmpresa.Checked = true;
                }
                ippersona = Int32.Parse(lector.GetValue(0).ToString());
            }
            lector.Close();
            command2 = new SqlCommand("select PERSONA.IDPERSONA, TELEFONO, TIPO from TELEFONO, PERSONA where TELEFONO.IDPERSONA=PERSONA.IDPERSONA and PERSONA.IDENTIFICACION = '" + tbCedula.Text + "' order by persona.IDPERSONA", conexion);
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
            conexion.Close();
            lector2.Close();
        }



        public bool validarEntrada()
        {
            //Console.WriteLine("alcance " + flagAlcance + "cedula " + flagCedula + "correo " + flagCorreo + "moviles " + flagMoviles + "nombre " + flagNombre + "sector " + flagSector + "telefonos " + flagTelefonos);
            if (flagNContacto  && flagCorreo && flagMoviles  && flagDescripcion && flagTelefonos )
            {
                
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


        private void Button1_Click(object sender, EventArgs e)
        {
            if (validarEntrada())
            {
                String tipo, tipoPago;
                if (rbEmpresa.Checked)
                {
                    tipo = rbEmpresa.Text;
                }
                else
                {
                    tipo = rbPersona.Text;
                }
                if (rbAcordado.Checked)
                {
                    tipoPago = rbAcordado.Text;
                }
                else
                {
                    tipoPago = rbDefinido.Text;
                }
                try
                {
                    SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SIGSTEC;Integrated Security=True");
                    conexion.Open();
                    SqlCommand command;
                    command = new SqlCommand("SP_ACTUALIZAR_CLIENTE", conexion);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@correo", tbCorreo.Text);
                    command.Parameters.AddWithValue("@idpersona", ippersona);
                    command.Parameters.AddWithValue("@nombre_contacto", tbNombreCont.Text);
                    command.Parameters.AddWithValue("@descripcion_contacto", tbDescripcion.Text);
                    command.Parameters.AddWithValue("@sla", cbSLA.Text);
                    command.Parameters.AddWithValue("@cuenta", tbCuenta.Text);
                    command.Parameters.AddWithValue("@tipo_pago", tipoPago);
                    command.Parameters.AddWithValue("@tipo", tipo);

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
                    MessageBox.Show("Cliente Modificado Correctamente", "Cliente Modificado");
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base:" + ex);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            bool flag = Validaciones.ComprobarFormatoEmail(tbCorreo.Text);
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

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //           MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
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

        private void TbTelefono1_TextChanged(object sender, EventArgs e)
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

        private void TbTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbTelefono2_TextChanged_1(object sender, EventArgs e)
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

        private void TbTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbCelular1_TextChanged(object sender, EventArgs e)
        {
            if (Validaciones.formatoCelular(tbCelular1.Text))
            {
                errorProvider1.SetError(tbCelular1, null);
                tbCelular1.ForeColor = Color.Green;
            }
            else
            {
                errorProvider1.SetError(tbCelular1, "El celular debe:\r\n" +
                    "- Iniciar con prefijo 09\r\n" +
                    "- Tener 10 dígitos");
                tbCelular1.ForeColor = Color.Red;
            }
        }

        private void TbCelular1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //               MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TbCelular2_TextChanged_1(object sender, EventArgs e)
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
    }
}
