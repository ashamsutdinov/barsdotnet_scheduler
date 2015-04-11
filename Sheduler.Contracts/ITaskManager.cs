namespace Sheduler.Contracts
{
    public interface ITaskManager
    {
        ITask Edit(int id, int authorId, string title);
        ITask GetById(int id);
    }
}