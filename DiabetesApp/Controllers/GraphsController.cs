using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DiabetesApp.Models;

namespace DiabetesApp.Controllers
{
    [Authorize]
    public class GraphsController : Controller
    {
        private InputModelDBContext db = new InputModelDBContext();
        
        //
        // GET: /Graphs/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DisplayBloodSugar()
        {
            var model = db.InputModels.Where(x => x.bloodSugarAmount != null && x.user == System.Web.HttpContext.Current.User.Identity.Name).Select(x => new { x.inputDate, x.bloodSugarAmount }).OrderBy(x => x.inputDate);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DisplayWeight()
        {
            var model = db.InputModels.Where(x => x.weightAmount != null && x.user == System.Web.HttpContext.Current.User.Identity.Name).Select(x => new { x.inputDate, x.weightAmount }).OrderBy(x => x.inputDate);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayA1C()
        {
            var endDate = DateTime.Now;
            var startDate = DateTime.Now.AddYears(-1);

            var model = db.InputModels.Where(x => x.a1cAmount != null && x.user == System.Web.HttpContext.Current.User.Identity.Name).Select(x => new { x.inputDate, x.a1cAmount }).OrderBy(x => x.inputDate);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DisplayCarbs()
        {
            var model = db.InputModels.Where(x => x.carbAmount != null && x.user == System.Web.HttpContext.Current.User.Identity.Name).Select(x => new { x.inputDate, x.carbAmount }).OrderBy(x => x.inputDate);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        

        
	}
}