using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesApp.ViewModels
{
    public class BloodSugarViewModel
    {
        [Required(ErrorMessage = "An entry date is required")]
        [Display(Name = "Input Date")]
        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }

        [Required(ErrorMessage = "Blood sugar entry is required")]
        [Display(Name="Blood Sugar")]
        [Range(1, 999, ErrorMessage="Entry not in acceptable range")]
        public int bloodSugarAmount { get; set; }
    }
}