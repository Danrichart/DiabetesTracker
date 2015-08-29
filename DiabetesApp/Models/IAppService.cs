using System;
using System.Collections.Generic;
using System.Linq;
using DiabetesApp.ViewModels;

namespace DiabetesApp.Models
{
    public interface IAppService
    {

        IEnumerable<InputModel> GetHistorytoPagedList(int? page);
        InputModel SelectModelID(int? id);
        void DeleteModel(InputModel model);
        void AddModelToDatabase(InputModel model);
        IOrderedQueryable GetBloodSugarData();
        IOrderedQueryable GetCarbohydrateData();
        IOrderedQueryable GetA1CData();
        IOrderedQueryable GetWeightData();
        void InputBloodSugarData(BloodSugarViewModel model);
        void InputCarbohydrateData(CarbViewModel model);
        void InputA1CData(A1CViewModel model);
        void InputWeightData(WeightViewModel model);
    }
}
