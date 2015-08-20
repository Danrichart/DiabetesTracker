using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesApp.ViewModels
{
    public class WeightViewModel
    {
        [Required(ErrorMessage="An entry date is required")]
        [Display(Name="Input Date")]
        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }

        [Required(ErrorMessage="A weight amount is required")]
        [Display(Name="Weight")]
        [Range(1, 500, ErrorMessage="Weight must be in range of 1 to 500")]
        public int weightAmount { get; set; }
    }
}