namespace Sheduler.Dal.Domain
{
    public class Task
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual int AuthorId { get; set; }
    }
}