using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using Sheduler.Contracts;

namespace Sheduler.Dal
{
    public class DatabaseManager : 
        IDatabaseManager 
    {
        public void Initialize()
        {
            var configuration = new Configuration();
            var nhConfig = configuration.Configure();
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            nhConfig.AddMapping(domainMapping);
            SessionFactory = nhConfig.BuildSessionFactory();
        }

        internal static ISessionFactory SessionFactory { get; private set; }
    }
}
