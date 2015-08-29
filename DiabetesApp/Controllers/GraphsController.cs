using System.Web.Mvc;
using DiabetesApp.Models;

namespace DiabetesApp.Controllers
{
    [Authorize]
    public class GraphsController : Controller
    {
        private AppServices service = new AppServices();
        
        //
        // GET: /Graphs/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DisplayBloodSugar()
        {
            var model = service.GetBloodSugarData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DisplayWeight()
        {
            var model = service.GetWeightData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayA1C()
        {

            var model = service.GetA1CData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayCarbs()
        {
            var model = service.GetCarbohydrateData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
	}
}