using System.Web.Mvc;
using DiabetesApp.ViewModels;
using DiabetesApp.Models;
using DiabetesApp.DataAbstraction;

namespace DiabetesApp.Controllers
{
    [Authorize]
    public class InputController : Controller
    {

        private Service service = new Service();
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
                service.InputBloodSugarData(model);
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

                service.InputWeightData(model);
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
                service.InputA1CData(model);
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
                service.InputCarbohydratesData(model);
                return RedirectToAction("Index", "Input");
            }
            return View(model);
        }
    }
}