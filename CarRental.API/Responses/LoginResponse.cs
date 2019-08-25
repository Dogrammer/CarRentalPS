using CarRental.Model.Models;

namespace CarRental.API.Responses
{
    public class LoginResponse : AppResponse
    {
        public string Token { get; set; }

        public User User { get; set; }
    }
}