using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CarRental.Core.Services.Contracts;
using CarRental.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Core.Services.Implementations
{
    // public class AuthService : AppService, IAuthService
    // {
    //     private readonly UserManager<User> UserManager;
    //     private readonly SignInManager<User> SignInManager;
    //     private readonly IConfiguration Configuration;

    //     public AuthService(UserManager<User> userManager,
    //                        SignInManager<User> signInManager,
    //                        IConfiguration configuration)
    //     {
    //         Configuration = configuration;
    //         SignInManager = signInManager;
    //         UserManager = userManager;
    //     }

        // public async Task<string> SignInAsync(string email, string password)
        // {
        //     var result = await SignInManager.PasswordSignInAsync(email, password, false, false);
        //     if (result.Succeeded)
        //     {
        //         var appUser = UserManager.Users.SingleOrDefault(r => r.Email == email);

        //         return GenerateJwtToken(email, appUser);
        //     }

        //     return null;
        // }

        // public async Task<string> RegisterAsync(string email, string password)
        // {
        //     var user = new User
        //     {
        //         UserName = email,
        //         Email = email
        //     };

        //     var result = await UserManager.CreateAsync(user, password);

        //     if (result.Succeeded)
        //     {
        //         await SignInManager.SignInAsync(user, false);
        //         return GenerateJwtToken(email, user);
        //     }

        //     return null;
        // }

        //  private string GenerateJwtToken(string email, AuthUser user)
        // {
        //     var claims = new List<Claim>
        //     {
        //         new Claim(JwtRegisteredClaimNames.Sub, email),
        //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        //     };

        //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]));
        //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //     var expires = DateTime.Now.AddDays(Convert.ToDouble(Configuration["JwtExpireDays"]));

        //      var token = new JwtSecurityToken(
        //         Configuration["JwtIssuer"],
        //         Configuration["JwtIssuer"],
        //         claims,
        //         expires: expires,
        //         signingCredentials: creds
        //     );

        //      return new JwtSecurityTokenHandler().WriteToken(token);
        // }
    
}