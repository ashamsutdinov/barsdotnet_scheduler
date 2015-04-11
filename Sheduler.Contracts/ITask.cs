namespace Sheduler.Contracts
{
    public interface ITask
    {
        int Id { get; set; }

        string Title { get; set; }

        int AuthorId { get; set; }
    }
}