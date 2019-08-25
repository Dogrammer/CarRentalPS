using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Model.Models
{
    public class City : BaseModel
    {
        
        [Required(ErrorMessage ="Naziv grada je obvezno polje.")]
        [StringLength(100, ErrorMessage = "Duljina naziva grada ne može biti veća od 100 znakova")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Poštanski kod je obvezno polje.")]
        [StringLength(10 ,ErrorMessage = "Zip kod mora biti maksimalno 10 znamenaka")]
        public string Zip { get; set; }
    }
}
