using AutoMapper;
using Sheduler.Contracts;
using Sheduler.Dal;
using DalUser = Sheduler.Dal.Domain.User;

namespace Sheduler.Data
{
    public class UserManager :
        IUserManager
    {
        private readonly PasswordHelper _passwordHelper = new PasswordHelper();

        public UserManager()
        {
            Mapper.CreateMap<User, DalUser>();
            Mapper.CreateMap<DalUser, User>();
        }

        public IUser Register(string login, string password)
        {
            using (var da = new UsersDa())
            {
                var existingDalUser = da.GetFirst(u => u.Login == login);
                if (existingDalUser != null)
                    return null;

                var salt = _passwordHelper.CreateSalt();
                var hash = _passwordHelper.GenerateSaltedHash(password, salt);

                var newUser = new User
                {
                    Login = login,
                    PasswordHash = hash,
                    Salt = salt
                };
                var newDalUser = da.Save(Mapper.Map<User, DalUser>(newUser));
                return Mapper.Map<DalUser, User>(newDalUser);
            }
        }

        public IUser CheckAndGet(string login, string password)
        {
            using (var da = new UsersDa())
            {
                var existingDalUser = da.GetFirst(u => u.Login == login);
                if (existingDalUser == null)
                    return null;

                var testHash = _passwordHelper.GenerateSaltedHash(password, existingDalUser.Salt);
                if (testHash != existingDalUser.PasswordHash)
                    return null;

                return Mapper.Map<DalUser, User>(existingDalUser);
            }
        }
    }
}
