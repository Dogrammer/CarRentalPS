using System.Threading.Tasks;
using CarRental.Model.Models;

namespace CarRental.Core.Services.Contracts
{
    public interface IUserService
    {
         Task<User> getByEmailAsync(string email);
    }
}