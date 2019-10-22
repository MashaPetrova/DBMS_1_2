using NHibernate;
using NHibernate.Cfg;

namespace ORM_P2
{
    public class HibernateHelper
    {
        private static ISessionFactory _sessionFactory; //связь кода и объектов с бд

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure(); //ищет файл cfg.xml парсит и понимает с какой бд мы работаем, где она лежит
                    cfg.AddAssembly(typeof(Club).Assembly);
                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }

        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession(); //нужен для конкретных действий с объектами
        }
    }
}
