using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DiabetesApp.Models;
using DiabetesApp.ViewModels;


namespace DiabetesApp.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<BloodSugarViewModel, InputModel>();
            Mapper.CreateMap<CarbViewModel, InputModel>();
            Mapper.CreateMap<A1CViewModel,InputModel>();
            Mapper.CreateMap<WeightViewModel, InputModel>();
        }
    }
}