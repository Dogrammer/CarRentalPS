using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Requests.Auth
{
    public class LoginRequest : AppRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}