using System.Web.Mvc;
using DiabetesApp.Models;
using DiabetesApp.DataAbstraction;

namespace DiabetesApp.Controllers
{
    [Authorize]
    public class GraphsController : Controller
    {
        private Service service = new Service();

        //
        // GET: /Graphs/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DisplayBloodSugar()
        {
            var model = service.GetHighChartBloodSugarData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DisplayWeight()
        {
            var model = service.GetHighChartWeightData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayA1C()
        {

            var model = service.GetHighCharA1CData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayCarbs()
        {
            var model = service.GetHighChartCarbohydrateData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
	}
}