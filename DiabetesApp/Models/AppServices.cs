using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using PagedList;
using DiabetesApp.ViewModels;
using System.Web;

namespace DiabetesApp.Models
{
    public class AppServices : IAppService
    {

        private InputModelDBContext _dbentity = new InputModelDBContext();
        private string _user = HttpContext.Current.User.Identity.Name.ToString();

        public IEnumerable<InputModel> GetHistorytoPagedList(int? page)
        {
            var pageSize = 15;
            var pageNumber = (page ?? 1);
            var historyData = _dbentity.InputModels
                .Where(x => x.user == _user)
                .OrderByDescending(x => x.inputDate);

            return historyData.ToPagedList(pageNumber, pageSize);
        }

        public InputModel SelectModelID(int? id)
        {

            var model = _dbentity.InputModels.Find(id);
            return model;
        }

        public void DeleteModel(InputModel model)
        {
            _dbentity.InputModels.Remove(model);
            _dbentity.SaveChanges();
        }

        public void AddModelToDatabase(InputModel model)
        {
            _dbentity.Entry(model).State = EntityState.Added;
            _dbentity.SaveChanges();
        }


        public IOrderedQueryable GetBloodSugarData()
        {
            var model = _dbentity.InputModels
                .Where(x => x.bloodSugarAmount != null && x.user == _user)
                .Select(x => new { x.inputDate, x.bloodSugarAmount })
                .OrderBy(x => x.inputDate);

            return model;
        }
        public IOrderedQueryable GetCarbohydrateData()
        {
            var model = _dbentity.InputModels
                .Where(x => x.carbAmount != null && x.user == _user)
                .Select(x => new { x.inputDate, x.carbAmount })
                .OrderBy(x => x.inputDate);

            return model;
        }
        public IOrderedQueryable GetA1CData()
        {
            var model = _dbentity.InputModels
                .Where(x => x.a1cAmount != null && x.user == _user)
                .Select(x => new { x.inputDate, x.a1cAmount })
                .OrderBy(x => x.inputDate);

            return model;
        }
        public IOrderedQueryable GetWeightData()
        {
            var model = _dbentity.InputModels
                .Where(x => x.weightAmount != null && x.user == _user)
                .Select(x => new { x.inputDate, x.weightAmount })
                .OrderBy(x => x.inputDate);

            return model;
        }

        public void InputBloodSugarData(BloodSugarViewModel model)
        {
            var inputModel = new InputModel
            {
                user = _user,
                bloodSugarAmount = model.bloodSugarAmount,
                inputDate = model.inputDate
            };

            AddModelToDatabase(inputModel);
        }
        public void InputCarbohydrateData(CarbViewModel model)
        {
            var inputModel = new InputModel
            {
                user = _user,
                carbAmount = model.carbAmount,
                inputDate = model.inputDate
            };

            AddModelToDatabase(inputModel);
        }
        public void InputA1CData(A1CViewModel model)
        {
            var inputModel = new InputModel
            {
                user = _user,
                a1cAmount = model.a1cAmount,
                inputDate = model.inputDate
            };

            AddModelToDatabase(inputModel);
        }
        public void InputWeightData(WeightViewModel model)
        {
            var inputModel = new InputModel
            {
                user = _user,
                weightAmount = model.weightAmount,
                inputDate = model.inputDate
            };

            AddModelToDatabase(inputModel);
        }
     }
}