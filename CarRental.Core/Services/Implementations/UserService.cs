using System.Linq;
using System.Threading.Tasks;
using CarRental.Core.Services.Contracts;
using CarRental.Infrastructure.DB;

namespace CarRental.Core.Services.Implementations
{
    // public class UserService : IUserService
    // {
    //     private readonly RentalContext _context;
    //     public UserService(RentalContext context)
    //     {
    //         _context = context;

    //     }
    //     public async Task<AuthUser> getByEmailAsync(string email)
    //     {
    //         return await _context.Users
    //             .Where(u => u.Email == email)
    //             .Select(u => new AuthUser {
    //                 Id = u.Id,
    //                 Email = u.Email
    //             }).FirstAsnyc();
    //     }
    // }
}