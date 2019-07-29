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

        public PantallaPrincipal()
        {
            InitializeComponent();

            TopMost = false;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            muestraDeCaso2.mostrarCasos();
        }


        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegCliente);
        }

        private void ModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabModCliente);
            modificaciónDeCliente1.mostrarCliente();

        }


        private void NuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegTécnico);
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabEliminarCliente);
            eliminaciónDeCliente1.mostrarDatosCompleto();
        }

        private void EliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabBajaTécnico);
            eliminaciónDeTécnico1.mostrarTecnicos();
        }

        private void NuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegCaso);

        }


        private void ModificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabCerrarCaso);
            registroDeCaso1.llenarCBVendedor();
            cierreDeCaso1.muestraCasos();
        }

        private void EliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegProd);

        }

        private void ModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabModTécnico);
            modificaciónDeTécnico1.mostrarTecnicos();
        }


        private void IngresarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegProd);
        }

        private void DarDeBajaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabDismProd);
            disminuciónDeProducto1.llenarTablaProductos();
        }

        private void AumentarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAumProd);
            aumentoDeProducto1.mostrarProducto();
        }

        private void CancelarCasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabCancelarCaso);
            cancelaciónDeCaso1.muestraCasos();
        }

        private void MostrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarCliente);
            muestraDeCliente1.llenarCampos();
        }

        private void MostrarTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarTécnico);
            muestraDeTécnico1.muestraTecnicos();
        }

        private void MostrarCasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMostrarCaso);
            muestraDeCaso1.mostrarCasos();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new InicioDeSesión().Show();
            this.Dispose();
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
            muestraDeProducto1.mostrarProductos();
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
            eliminaciónDeUsuario1.mostrarDatos();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void MuestraDeCaso2_Load(object sender, EventArgs e)
        {

        }

        private void FinalizarCasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabFinalizarCaso);
        }

        private void AsignarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAsignarProducto);
            asignaciónDeProductos1.llenarTabla();
        }

        private void MSAlzarCliente_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAlzarCliente);
            darDeAltaCliente1.mostrarDatosCompleto();
        }

        private void MSAlzarTécnico_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAlzarTécnico);
            darDeAltaTécnico1.mostrarTecnicos();
        }

        private void RegistrarUsusarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRegUsuario);
        }

        private void EliminarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabEliminarUsuario);
            eliminaciónDeUsuario1.mostrarDatos();
        }

        private void DarDeAltaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabAltaUsuario);
            dadaDeAltaUsuario1.mostrarDatos();
        }

        private void RecuperarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabRecuperar);
            recuperaciónContraseña1.mostrarDatos();
        }
    }
}
