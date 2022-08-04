using NHibernate;
using WindowsForms.domain.model;

namespace WindowsForms.domain.DAO.NHibernate
{
    public class UsuarioNHibernateDAO
    {
        public IList<Usuario> GetUsuarios()
        {
            using (ISession session = SessionFactory.OpenSession)
            {
                IQuery query = session.CreateQuery("FROM Usuario");
                return query.List<Usuario>();
            }
        }
    }
}
