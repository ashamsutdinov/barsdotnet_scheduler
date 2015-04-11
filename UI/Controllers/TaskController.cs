using System.Web.Mvc;
using AutoMapper;
using Sheduler.Contracts;
using Sheduler.Data;
using UI.Models;

namespace UI.Controllers
{
    public class TaskController :
        Controller
    {
        private readonly ITaskManager _taskManager;

        public TaskController()
        {
            _taskManager = Services.Factory.Get<ITaskManager>();
            Mapper.CreateMap<ITask, EditTaskModel>();
            Mapper.CreateMap<EditTaskModel, Task>();
        }

        public ActionResult Edit(int id = 0)
        {
            if (id > 0)
            {
                var task = _taskManager.GetById(id);
                if (task == null)
                    return Content("Task not found");

                var model = Mapper.Map<ITask, EditTaskModel>(task);
                return View(model);
            }
            else
            {
                var model = new EditTaskModel();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditTaskModel model)
        {
            var savedTask = _taskManager.Edit(model.Id, model.AuthorId, model.Title);
            return Json(savedTask);
        }
    }
}