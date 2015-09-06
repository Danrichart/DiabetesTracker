using System.Web.Mvc;
using DiabetesApp.Models;
using DiabetesApp.DataAbstraction;


namespace DiabetesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private Service service = new Service();

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
            var model = service.HistoryToPagedList(page);
            return View(model);
        }

        
        public ActionResult Delete(int? id)
        {
            var model = service.SelectModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = service.SelectModel(id);
            service.DeleteModel(model);
            return RedirectToAction("History");
        }
    }
}