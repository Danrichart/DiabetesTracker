using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiabetesApp.ViewModels;
using DiabetesApp.Models;
using System.Data.Entity;

namespace DiabetesApp.Controllers
{
    [Authorize]
    public class InputController : Controller
    {

        private InputModelDBContext db = new InputModelDBContext();
        //
        // GET: /Input/
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Input/BloodSugar
        public ActionResult BloodSugar()
        {
            return View();
        }

        // POST: /Input/BloodSugar
        [HttpPost]
        public ActionResult BloodSugar(BloodSugarViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inputModel = new InputModel
                {
                    user = System.Web.HttpContext.Current.User.Identity.Name,
                    bloodSugarAmount = model.bloodSugarAmount,
                    inputDate = model.inputDate
                };

                db.Entry(inputModel).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index", "Input");
            }
            return View(model);
        }



        //GET: /Input/Weight
        public ActionResult Weight()
        {
            return View();
        }

        // POST: /Input/Weight
        [HttpPost]
        public ActionResult Weight(WeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inputModel = new InputModel
                {
                    user = System.Web.HttpContext.Current.User.Identity.Name,
                    weightAmount = model.weightAmount,
                    inputDate = model.inputDate
                };

                db.Entry(inputModel).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index", "Input");
            }
            return View(model);
        }

        //GET: /Input/A1C
        public ActionResult A1C()
        {
            return View();
        }

        // POST: /Input/A1C
        [HttpPost]
        public ActionResult A1C(A1CViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inputModel = new InputModel
                {
                    user = System.Web.HttpContext.Current.User.Identity.Name,
                    a1cAmount = model.a1cAmount,
                    inputDate = model.inputDate
                };

                db.Entry(inputModel).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index", "Input");
            }
            return View(model);
        }




        //GET: /Input/Carbs
        public ActionResult Carbs()
        {
            return View();
        }

        // POST: /Input/Carbs
        [HttpPost]
        public ActionResult Carbs(CarbViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inputModel = new InputModel
                {
                    user = System.Web.HttpContext.Current.User.Identity.Name,
                    carbAmount = model.carbAmount,
                    inputDate = model.inputDate
                };

                db.Entry(inputModel).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index", "Input");
            }
            return View(model);
        }
    }
}