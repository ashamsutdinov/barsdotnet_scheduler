using System;
using AutoMapper;
using Sheduler.Contracts;
using Sheduler.Dal;
using DalTask = Sheduler.Dal.Domain.Task;

namespace Sheduler.Data
{
    public class TaskManager :
        ITaskManager
    {
        public TaskManager()
        {
            Mapper.CreateMap<DalTask, Task>();
            Mapper.CreateMap<Task, DalTask>();
        }

        public ITask Edit(int id, int authorId, string title)
        {
            using (var da = new TasksDa())
            {
                if (id > 0)
                {
                    var existingTask = da.GetById(id);
                    if (existingTask == null)
                        return null;

                    existingTask.AuthorId = authorId;
                    existingTask.Title = title;
                    da.Save(existingTask);
                    return Mapper.Map<DalTask, Task>(existingTask);
                }
                else
                {
                    var task = new Task
                    {
                        AuthorId = authorId,
                        Title = title
                    };
                    var newDalTask = da.Save(Mapper.Map<Task, DalTask>(task));
                    return Mapper.Map<DalTask, Task>(newDalTask);
                }
            }
        }

        public ITask GetById(int id)
        {
            using (var da = new TasksDa())
            {
                var dalTask = da.GetById(id);
                return dalTask == null ? null : Mapper.Map<DalTask, Task>(dalTask);
            }
        }
    }
}