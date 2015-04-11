namespace Sheduler.Dal.Domain
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string Salt { get; set; }
    }
}
