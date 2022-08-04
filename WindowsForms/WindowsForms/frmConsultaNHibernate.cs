using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using WindowsForms.domain.service;

namespace WindowsForms
{
    public partial class frmConsultaNHibernate : Form
    {
        public frmConsultaNHibernate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var teste = monthCalendar1.SelectionRange.Start.ToString();
            var usuarioService = new UsuarioService();
            dataGridView1.DataSource = usuarioService.GetUsuarios();
        }
    }
}
