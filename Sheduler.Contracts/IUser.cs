namespace Sheduler.Contracts
{
    public interface IUser
    {
        int Id { get; set; }

        string Login { get; set; }

        string PasswordHash { get; set; }

        string Salt { get; set; }
    }
}