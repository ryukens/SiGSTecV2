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
    public partial class PantallaPrincipal : Form
    {
        InicioDeSesión inicioDeSesión;
        public PantallaPrincipal(InicioDeSesión inicioDeSesión)
        {
            InitializeComponent();
            this.inicioDeSesión = inicioDeSesión;
            TopMost = false;
        }
                       
        private void Button1_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
                
        }

        
        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegCliente);
        }

        private void ModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabModCliente);
        }


        private void NuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegTécnico);
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabEliminarCliente);
        }

        private void EliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabBajaTécnico);
        }

        private void NuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegCaso);
        }

        
        private void ModificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabCerrarCaso);  
                       
        }

        private void EliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegProd);
            
        }
           
        private void ModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabModTécnico);
        }


        private void IngresarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegProd);
        }

        private void DarDeBajaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabDismProd);
        }

        private void AumentarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAumProd);
        }

        private void CancelarCasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabCancelarCaso);
        }

        private void MostrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarCliente);
        }

        private void MostrarTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarTécnico);
        }

        private void MostrarCasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarCaso);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            inicioDeSesión.Show();
        }

        private void GenerarInformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabGenInforme);
        }

        private void VerDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabVerDetalle);
        }

        
        private void MuestraProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarProducto);
        }

        
        private void PantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void RegistrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegUsuario);
        }

        private void EliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabEliminarUsuario);
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void MuestraDeCaso2_Load(object sender, EventArgs e)
        {

        }
    }
}
