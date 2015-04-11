using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Sheduler.Dal.Domain;

namespace Sheduler.Dal.Mappings
{
    public class UsersMap :
        ClassMapping<User>
    {
        public UsersMap()
        {
            Table("Users");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.Login);
            Property(u => u.PasswordHash);
            Property(u => u.Salt);
        }
    }
}
