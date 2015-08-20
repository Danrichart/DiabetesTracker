using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DiabetesApp.Models
{
    public class InputModel
    {
        public int ID { get; set; }
        public string user { get; set; }

        [Display(Name="Entry Date")]
        public DateTime inputDate { get; set; }

        [Display(Name="Blood Sugar")]
        public int? bloodSugarAmount { get; set; }

        [Display(Name="Weight")]
        public int? weightAmount { get; set; }

        [Display(Name="Carbohydrates")]
        public int? carbAmount { get; set; }

        [Display(Name="A1C")]
        public decimal? a1cAmount { get; set; }
    }

    public class InputModelDBContext : DbContext
    {
        public DbSet<InputModel> InputModels { get; set; }
    }
}