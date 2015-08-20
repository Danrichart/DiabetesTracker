using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesApp.ViewModels
{
    public class CarbViewModel
    {
        [Required(ErrorMessage = "An entry date is required")]
        [Display(Name = "Input Date")]
        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }

        [Required(ErrorMessage="Carbohydrate entry is required")]
        [Display(Name="Carbohydrates")]
        [Range(1, 999, ErrorMessage="Entry not in acceptable range")]
        public int carbAmount { get; set; }
    }
}