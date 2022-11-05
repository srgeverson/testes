using System;
using System.Web.UI;
using AppClassLibraryDomain.model;
using AppClassLibraryDomain.service;
using Spring.Context;
using Spring.Context.Support;

namespace SisContatos
{
    public partial class FormListarEmSQL : Page
    {
        private static IApplicationContext CONTEXT = ContextRegistry.GetContext();
        private IContatoService contatoService;
        private IUsuarioService usuarioService;

        public IContatoService ContatoService { set => contatoService = value; }
        public IUsuarioService UsuarioService { set => usuarioService = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //contatoService = new ContatoDAO();
            //if (!IsPostBack)
            //{
            //}
            if (contatoService == null)
                contatoService = (IContatoService)CONTEXT.GetObject("ContatoService");
            if (usuarioService == null)
                usuarioService = (IUsuarioService)CONTEXT.GetObject("UsuarioService");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var contato = new Contato();
                int id;
                if (int.TryParse(txtId.Text, out id))
                    contato.Id = int.Parse(txtId.Text);
                contato.Nome = txtNome.Text;
                contato.SobreNome = txtSobreNome.Text;
                contato.Email = txtEmail.Text;
                contato.Telefone = txtTelefone.Text;
                //gdvContatos.DataSource = contatoService.Listar(contato);
                gdvContatos.DataSource = usuarioService.Listar(new Usuario());
                gdvContatos.DataBind();
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
                pnlErro.Visible = true;
            }
        }
    }
}