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
    public partial class AsignaciónValorFinal : UserControl
    {
        public AsignaciónValorFinal()
        {
            InitializeComponent();
        }

        TabControl tabControl;
        TabPage tabInicio;
        public AsignaciónValorFinal(TabControl tabControl, TabPage tabInicio)
        {
            InitializeComponent();
            this.tabControl = tabControl;
            this.tabInicio = tabInicio;
        }

        private void BAsignación_Click(object sender, EventArgs e)
        {
            ValorFinal valorFinal = new ValorFinal();
            valorFinal.ShowDialog();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabInicio);
            tbBuscar.ResetText();
        }
    }
}
