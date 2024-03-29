using System;
using System.Threading.Tasks;
using CarRental.API.Requests.Auth;
using CarRental.API.Responses;
using CarRental.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers.Auth
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthController : AppController
    {
        private readonly IAuthService AuthService;
        private readonly IUserService UserService;

        public AuthController(
            IAuthService authService,
            IUserService userService
            )
        {
            AuthService = authService;
            UserService = userService;
        }
        
        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginRequest request)
        {
            string token = await AuthService.SignInAsync(request.Email, request.Password);

            if(string.IsNullOrEmpty(token))
                throw new ApplicationException("INVALID_LOGIN_ATTEMPT");

            return token;
        }
       
        [HttpPost("register")]
        public async Task<RegisterResponse> Register([FromBody] RegisterRequest request)
        {
            string token = await AuthService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password, request.DateOfBirth, request.DrivingLicenceNumber);
            var user = await UserService.getByEmailAsync(request.Email);

            if(string.IsNullOrEmpty(token))
                throw new ApplicationException("UNKNOWN_ERROR");
            
            return new RegisterResponse {
                User = new AuthUserResponse {
                    Id = 1,
                    Email = user.Email
                },
                Token = token
            };
        }

        [Authorize]
        [HttpGet]
        public object Protected()
        {
            return "Protected area";
        }
    }
}
