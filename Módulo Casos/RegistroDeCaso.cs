using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace proyectoPantalla
{
    public partial class RegistroDeCaso : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog = SIGSTEC; Integrated Security = True");

        TabControl tabControl;
        TabPage tabInicio;
        public RegistroDeCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            timer1.Enabled = true;
            cbSLA.SelectedIndex = 0;
            llenarCBVendedor();
            asignarNumeroCaso(lCaso);
            if (cbVendedor.Items.Count != 0)
            {
                cbVendedor.SelectedIndex = 0;
            }
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        public void llenarCBVendedor()
        {
            cbVendedor.Items.Clear();
            conexion.Open();
            String consulta1 = "select p.nombre from persona as p join usuario as u on p.idpersona = u.idpersona where u.TIPO = 'Empleado De Ventas' order by p.nombre;";
            SqlCommand comando1 = new SqlCommand(consulta1, conexion);
            SqlDataReader reader = comando1.ExecuteReader();
            while (reader.Read())
            {
                cbVendedor.Items.Add(reader[0].ToString());
            }

            
            if (cbVendedor.Items.Count > 0)
            {
                cbVendedor.SelectedIndex = 0;
            }

            conexion.Close();

        }

        


        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            SelecciónDeCliente selecciónDeCliente = new SelecciónDeCliente(lClienteSeleccionado, lIdCliente);
            selecciónDeCliente.ShowDialog();
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            SelecciónDeTécnico selecciónDeTécnico = new SelecciónDeTécnico(lTecnicoSeleccionado, lIdTecnico);
            selecciónDeTécnico.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            lFechaActual.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void asignarNumeroCaso(Label label)
        {
            String numeroConsulta="";
            string solofecha = "";
            string solonum = "";
            conexion.Open();

            String now = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));

            SqlCommand comando1 = new SqlCommand("SP_SACAR_NUMEROCASO_MAXIMO", conexion);
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.ExecuteNonQuery();
            SqlDataReader consulta = comando1.ExecuteReader();
            String ultimoRegistro = consulta.ToString();
            while (consulta.Read())
            {

                numeroConsulta = consulta.GetString(0);
            }
            //  label.Text = consulta.GetString(0);           

            conexion.Close();
            if (numeroConsulta.Length < 10)
            {
                solofecha = Convert.ToString(DateTime.Now) + "-001";
            }
            else
            {
                solofecha = numeroConsulta.Substring(0, 10);
                solonum = numeroConsulta.Substring(11);
            }
            

         //   MessageBox.Show( "fecha hoy" + now + " y fecha sacada de la base " + solofecha );

            if (solofecha != now)
            {
                String numeroCASO = now + "-001";
                label.Text = numeroCASO;


            }
            else if(solofecha == now)
            {
                int solonumINT = Int32.Parse(solonum);
                solonumINT = solonumINT + 1;

               String numeritosNumeroCASO = solonumINT.ToString().PadLeft(3, '0');


                String numeroCASO = now + "-" + numeritosNumeroCASO;


                label.Text = numeroCASO.ToString().PadLeft(3, '0');




            }



        }




        private void limpiarCampos()
        {
            tbInformeInicial.ResetText();
            tbSector.ResetText();
            cbSLA.SelectedIndex = 0;
            cbVendedor.SelectedIndex = 0;
            lClienteSeleccionado.Text = "CLIENTE SIN SELECCIONAR";
            lTecnicoSeleccionado.Text = "TÉCNICO SIN SELECCIONAR";
            lIdTecnico.Text = "id del técnico";
            lIdCliente.Text = "id del Cliente";
            lIdUsuario.Text = "id del Usuario";

            asignarNumeroCaso(lCaso);
        }


        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            limpiarCampos();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {

            bool flagVacios = ValidarCamposVacios();
            if (flagVacios == true)
            {
                conexion.Open();

                int idt = int.Parse(lIdTecnico.Text);
                int idc = int.Parse(lIdCliente.Text);
                String nombreu = lIdUsuario.Text;

                SqlCommand comando1 = new SqlCommand("SP_REGISTRO_CASO", conexion);
                comando1.CommandType = CommandType.StoredProcedure;
                comando1.Parameters.AddWithValue("@IDTECNICO", idt);
                comando1.Parameters.AddWithValue("@IDUSUARIO", cbVendedor.GetItemText(cbVendedor.SelectedItem));
                comando1.Parameters.AddWithValue("@IDCLIENTE", idc);
                comando1.Parameters.AddWithValue("@NUMERO", lCaso.Text);
                comando1.Parameters.AddWithValue("@FECHA", lFechaActual.Text);
                comando1.Parameters.AddWithValue("@SLA", cbSLA.Text);
                comando1.Parameters.AddWithValue("@INFORME_INICIAL", tbInformeInicial.Text);
                comando1.Parameters.AddWithValue("@SECTOR", tbSector.Text);
                comando1.ExecuteNonQuery();
                MessageBox.Show("Caso Registrado Correctamente", "Caso Registrado");
            }
            else
            {
                
                limpiarCampos();
                MessageBox.Show("Existen campos vacíos", "Campos Vacíos");
            }

            conexion.Close();
            limpiarCampos();
        }


        public bool ValidarCamposVacios()
        {
            bool flag = true;
            if (tbSector.Text.Equals(""))
            {
                flag = false;
            }
            if (lClienteSeleccionado.Text.Equals("CLIENTE SIN SELECCIONAR"))
            {
                flag = false;
            }
            if (lTecnicoSeleccionado.Text.Equals("TÉCNICO SIN SELECCIONAR"))
            {
                flag = false;
            }
            if (tbInformeInicial.Text.Equals(""))
            {
                flag = false;
            }

            return flag;
        }

        private void LClienteSeleccionado_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label1_Click_2(object sender, EventArgs e)
        {

        }

        private void CbVendedor_TextChanged(object sender, EventArgs e)
        {
            lIdUsuario.Text = cbVendedor.SelectedItem.ToString();

        }

        private void TbInformeInicial_TextChanged(object sender, EventArgs e)
        {
        }

        private void LFechaActual_Click(object sender, EventArgs e)
        {
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
