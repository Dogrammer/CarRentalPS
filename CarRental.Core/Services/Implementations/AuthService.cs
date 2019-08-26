using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Services.Contracts;
using CarRental.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace CarRental.Core.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration Configuration;

        public AuthService(UserManager<User> userManager,
                           SignInManager<User> signInManager,
                           Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public async Task<string> SignInAsync(string email, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(email, password, false, false);
            if (result.Succeeded)
            {
                var appUser = UserManager.Users.SingleOrDefault(r => r.Email == email);

                return GenerateJwtToken(email, appUser);
            }

            return null;
        }

        public async Task<string> RegisterAsync(string firstName, string lastName, string email, string password, DateTime dob, string drivingLicenceNumber)
        {
            var user = new User
            {
                UserName = email,
                Email = email,
                DateOfBirth = dob,
                DrivingLicenceNumber = drivingLicenceNumber,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await UserManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
                return GenerateJwtToken(email, user);
            }

            return null;
        }

        private string GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
               Configuration["JwtIssuer"],
               Configuration["JwtIssuer"],
               claims,
               expires: expires,
               signingCredentials: creds
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}

    