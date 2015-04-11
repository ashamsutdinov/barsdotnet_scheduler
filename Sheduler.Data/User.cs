using Sheduler.Contracts;

namespace Sheduler.Data
{
    public class User :
        IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}