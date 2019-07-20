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

namespace proyectoPantalla
{
    public partial class RegistroDeCaso : UserControl
    {
        SqlConnection conexion = new SqlConnection("Data Source =.; Initial Catalog = SIGSTEC; Integrated Security = True");

        
        public RegistroDeCaso()
        {
            InitializeComponent();
            timer1.Enabled = true;
            cbSLA.SelectedIndex = 0;
            llenarCBVendedor();
            if(cbVendedor.Items.Count != 0)
            {
                cbVendedor.SelectedIndex = 0;

            }


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

            conexion.Close();

            if(cbVendedor.Items.Count > 0)
            {
                cbVendedor.SelectedIndex = 0;
            }
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
            lFechaActual.Text = DateTime.Now.ToString();
        }

        private void Label12_Click(object sender, EventArgs e)
        {

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

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {

            limpiarCampos();


        }
        
        private void BAceptar_Click(object sender, EventArgs e)
        {
            conexion.Open();


            //String consulta1 = "insert into caso(IDUSUARIO, IDTECNICO, IDCLIENTE, NUMERO, FECHA, SLA, INFORME_INICIAL, SECTOR, ESTADO, PARTE_PATH, INFORME_FINAL) values((select IDPERSONA from PERSONA where NOMBRE = @USUARIO), @IDTECNICO, @IDCLIENTE, @NUMERO, @FECHA, @SLA, @INFORME_INICIAL, @SECTOR, 'ABIERTO', 'No asignado', 'No Asigando'); ";
          

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

            conexion.Close();

            limpiarCampos();

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
    }
}
