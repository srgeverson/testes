using AppClassLibraryDomain.model;
using NHibernate;
using System.Collections.Generic;

namespace AppClassLibraryDomain.DAO.NHibernate
{
    public class UsuarioNHibernateDAO
    {
        public IList<Usuario> GetUsuarios()
        {
            using (var session = SessionFactory.OpenSession)
            {
                IQuery query = session.CreateQuery("FROM Usuario");
                return query.List<Usuario>();
            }
        }
    }
}
