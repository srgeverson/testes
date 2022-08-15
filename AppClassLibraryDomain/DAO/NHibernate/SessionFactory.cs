using NHibernate;
using NHibernate.Cfg;
using System;

namespace AppClassLibraryDomain.DAO.NHibernate
{
    public sealed class SessionFactory
    {
        private static volatile ISessionFactory sessionFactory;
        private static object syncRoot = new Object();

        public static ISession OpenSession
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (sessionFactory == null)
                        {
                            var configuration = new Configuration();
                            object value = configuration.Configure();
                            sessionFactory = configuration.BuildSessionFactory();
                            //  configuration.AddAssembly(Assembly.GetCallingAssembly());
                        }
                    }
                }
                return sessionFactory.OpenSession();
            }
        }
    }
}
