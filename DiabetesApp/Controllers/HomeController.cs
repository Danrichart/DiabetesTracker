using System.Web.Mvc;
using DiabetesApp.Models;


namespace DiabetesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private AppServices service = new AppServices();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult History(int? page)
        {
            var model = service.GetHistorytoPagedList(page);
            return View(model);
        }

        
        public ActionResult Delete(int? id)
        {
            var model = service.SelectModelID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = service.SelectModelID(id);
            service.DeleteModel(model);
            return RedirectToAction("History");
        }
    }
}