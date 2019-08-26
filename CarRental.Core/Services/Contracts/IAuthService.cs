using System;
using System.Threading.Tasks;

namespace CarRental.Core.Services.Contracts
{
    public interface IAuthService : IAppService
    {
        Task<string> SignInAsync(string email, string password);
        Task<string> RegisterAsync(string firstName, string lastName, string email, string password, DateTime birthday, string drivingLicenceNumber);
    }
}