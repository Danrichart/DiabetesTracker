using System;
using System.ComponentModel.DataAnnotations;

namespace DiabetesApp.ViewModels
{
    public class A1CViewModel
    {
        [Required(ErrorMessage = "An entry date is required")]
        [Display(Name = "Input Date")]
        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }

        [Required(ErrorMessage="An A1C amount is required")]
        [Display(Name="A1C")]
        [Range(0.00, 30.00, ErrorMessage="Range must fall between 0.00 and 30.00")]
        public decimal a1cAmount { get; set; }
    }
}