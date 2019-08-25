using System.ComponentModel.DataAnnotations;

namespace CarRental.Model.Models
{
    public class Location : BaseModel
    {

        [Required(ErrorMessage="Polje 'ime lokacije' je obvezno polje."), StringLength(100, ErrorMessage = " Duljina naziva lokacije smije biti maksimalno 100 znakova")]
        public string Name { get; set; }
        //[JsonIgnore]
        public City City { get; set; }

        [Required(ErrorMessage="Polje 'grad' je obvezno polje."), Range(1, int.MaxValue, ErrorMessage="Id stranog kljuca mora biti u itnervalu od 1 do maks")]
        public int CityId { get; set; }
    }
}
