using Sheduler.Contracts;

namespace Sheduler.Data
{
    public class Task :
        ITask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }
    }
}