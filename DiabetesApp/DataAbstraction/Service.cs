using DiabetesApp.Models;
using DiabetesApp.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using AutoMapper;
using DiabetesApp.DataAbstraction;

namespace DiabetesApp.DataAbstraction
{
    public class Service
    {
        private Repository<InputModel> repository;
        private string _user = HttpContext.Current.User.Identity.Name.ToString();

        public Service()
        {
            this.repository = new Repository<InputModel>();
        }
        public Service(Repository<InputModel> repository)
        {
            this.repository = repository;
        }


        public void AddModel(InputModel model){
            repository.Add(model);
            repository.Save();
        }

        public void DeleteModel(InputModel model)
        {
            repository.Delete(model);
            repository.Save();
        }

        public InputModel SelectModel(int? id)
        {
            return repository.SelectModelID(id);
        }

        public IEnumerable<InputModel> HistoryToPagedList(int? page)
        {
            var model = repository.SelectDataByParams(x => x.user == _user, x => x.OrderByDescending(y => y.inputDate));
            var pageSize = 15;
            var pageNumber = (page ?? 1);
            return model.ToPagedList(pageNumber, pageSize);
        }

        public IEnumerable GetHighChartBloodSugarData()
        {
            var model = repository.SelectDataByParams(x => x.bloodSugarAmount != null && x.user == _user, x => x.OrderBy(y => y.inputDate));
            return model.Select(x => new { x.inputDate, x.weightAmount });
        }
        public IEnumerable GetHighChartWeightData()
        {
            var model = repository.SelectDataByParams(x => x.weightAmount != null && x.user == _user, x => x.OrderBy(y => y.inputDate));
            return model.Select(x => new { x.inputDate, x.weightAmount });
        }
        public IEnumerable GetHighChartCarbohydrateData()
        {
            var model = repository.SelectDataByParams(x => x.carbAmount != null && x.user == _user, x => x.OrderBy(y => y.inputDate));
            return model.Select(x => new { x.inputDate, x.carbAmount });
        }
        public IEnumerable GetHighCharA1CData()
        {
            var model = repository.SelectDataByParams(x => x.a1cAmount != null && x.user == _user, x => x.OrderBy(y => y.inputDate));
            return model.Select(x => new { x.inputDate, x.a1cAmount });
        }

        
        public void InputWeightData(WeightViewModel model)
        {
            InputModel dataMappedModel = Mapper.Map<WeightViewModel, InputModel>(model);
            dataMappedModel.user = _user;
            AddModel(dataMappedModel);
        }
        public void InputBloodSugarData(BloodSugarViewModel model)
        {
            InputModel dataMappedModel = Mapper.Map<BloodSugarViewModel, InputModel>(model);
            dataMappedModel.user = _user;
            AddModel(dataMappedModel);   
        }
        public void InputA1CData(A1CViewModel model)
        {
            InputModel dataMappedModel = Mapper.Map<A1CViewModel, InputModel>(model);
            dataMappedModel.user = _user;
            AddModel(dataMappedModel);
        }
        public void InputCarbohydratesData(CarbViewModel model)
        {
            InputModel dataMappedModel = Mapper.Map<CarbViewModel, InputModel>(model);
            dataMappedModel.user = _user;
            AddModel(dataMappedModel);
        }

        
       

    }
}