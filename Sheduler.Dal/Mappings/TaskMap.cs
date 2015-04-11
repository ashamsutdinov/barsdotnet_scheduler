using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Sheduler.Dal.Domain;

namespace Sheduler.Dal.Mappings
{
    public class TaskMap :
        ClassMapping<Task>
    {
        public TaskMap()
        {
            Table("Tasks");
            Id(t => t.Id, m => m.Generator(Generators.Identity));
            Property(t => t.Title);
            Property(t => t.AuthorId);
        }
    }
}