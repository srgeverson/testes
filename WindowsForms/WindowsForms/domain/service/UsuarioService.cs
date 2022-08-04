using WindowsForms.domain.DAO.NHibernate;
using WindowsForms.domain.model;

namespace WindowsForms.domain.service
{
    public class UsuarioService
    {
        private UsuarioNHibernateDAO usuarioNHibernateDAO;

        public UsuarioService()
        {
            this.usuarioNHibernateDAO = new UsuarioNHibernateDAO();
        }

        public IList<Usuario> GetUsuarios()
        {
            return this.usuarioNHibernateDAO.GetUsuarios();
        }
    }
}
