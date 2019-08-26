using System.Linq;
using System.Threading.Tasks;
using CarRental.Core.Services.Contracts;
using CarRental.Infrastructure.DB;
using CarRental.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly CarRentalContext _context;
        public UserService(CarRentalContext context)
        {
            _context = context;

        }
        public async Task<User> getByEmailAsync(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new User {
                    Id = u.Id,
                    Email = u.Email
                }).FirstAsync();
        }
    }
}