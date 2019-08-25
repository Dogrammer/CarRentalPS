using System.ComponentModel.DataAnnotations;
using CarRental.Model.Models;

namespace CarRental.Model.Models
{
     public class CarCategory : BaseModel
    {
        
        [Required(ErrorMessage = "Ime kategorije vozila je obvezno polje"), StringLength(100, ErrorMessage = "Duljina naziva kategorije vozila ne može biti veća od 100 znakova!")]
        public string Name { get; set; }
    }
}