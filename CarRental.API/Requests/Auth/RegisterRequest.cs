using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Requests.Auth
{
    public class RegisterRequest : AppRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string DrivingLicenceNumber { get; set; }

    }
}