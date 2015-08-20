using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiabetesApp.Models;
using System.Data.Entity;
using PagedList;


namespace DiabetesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private InputModelDBContext db = new InputModelDBContext();

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
            var models = db.InputModels
            .Where(x => x.user == System.Web.HttpContext.Current.User.Identity.Name)
            .OrderByDescending(x => x.inputDate);

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(models.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete(int? id)
        {
            var model = db.InputModels.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = db.InputModels.Find(id);
            db.InputModels.Remove(model);
            db.SaveChanges();

            return RedirectToAction("History");
        }
    }
}