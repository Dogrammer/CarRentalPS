using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRental.Model.Models;

namespace CarRental.Model.Models
{
    public class Car : BaseModel
    {
        
        [Required(ErrorMessage ="Brand je obvezno polje"), StringLength(150, ErrorMessage="Maksimalna duljina naziva Branda je 150 znakova.")]
        public string Brand { get; set; }
        
        [Required(ErrorMessage ="Brand je obvezno polje"), StringLength(100, ErrorMessage ="Maksimalna duljina naziva branda je 100 znakova.")]
        public string Model { get; set; }
        
        [Range(1885,2019, ErrorMessage = "Godina proizvodnje smije biti izmedu 1885-2019 godine.") ]
        public int ProductionYear { get; set; }

        [Range(0, 1000000, ErrorMessage = "Kilometraža mora biti u intervalu od 0 - 1000000")]
        public int Mileage { get; set; }
        
        public string Color { get; set; }
        //[JsonIgnore]
        public CarCategory CarCategory { get; set; }
        
        [Required(ErrorMessage="CarCategory je obvezno polje."), Range(1,int.MaxValue, ErrorMessage = "Strani Ključ ne može biti negativan.")]
        public int CarCategoryId { get; set; }
    }
}
