using System;

namespace CarRental.API.Dtos
{
    public class CustomerForListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
    }
}