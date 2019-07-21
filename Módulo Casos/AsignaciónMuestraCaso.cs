﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoPantalla.Módulo_Casos
{
    public partial class AsignaciónMuestraCaso : UserControl
    {
        public AsignaciónMuestraCaso()
        {
            InitializeComponent();
        }

        TabControl tabControl;
        TabPage tabInicio;
        public AsignaciónMuestraCaso(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SelecciónDeProductos selecciónDeProductos = new SelecciónDeProductos();
            selecciónDeProductos.ShowDialog();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }
    }
}
