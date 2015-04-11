using System.Web.Mvc;
using Sheduler.Contracts;

namespace UI.Controllers
{
    public class HomeController : 
        Controller
    {
        private readonly IUserManager _userManager;

        public HomeController()
        {
            _userManager = Services.Factory.Get<IUserManager>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string login, string password)
        {
            var user = _userManager.Register(login, password);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Authorize(string login, string password)
        {
            var user = _userManager.CheckAndGet(login, password);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}
