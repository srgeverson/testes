using AppClassLibraryDomain.service;

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
            try
            {
                //var teste = monthCalendar1.SelectionRange.Start.ToString();
                var usuarioService = new UsuarioService();
                dataGridView1.DataSource = usuarioService.GetUsuarios();
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Erro ao listar usuários: ", ex.Message));
            }
        }
    }
}
