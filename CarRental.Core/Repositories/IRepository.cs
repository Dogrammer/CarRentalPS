using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Core.Helpers;
using CarRental.Model.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CarRental.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
         Task<T> Add(T entity);
         Task<T> GetById(int id);
         Task<IEnumerable<T>> Get();
         Task<T> Remove(T entity);
         Task Save();
         Task<T> Update(T entity);
         Task Patch(JsonPatchDocument<T> entity, int id);

         //pagination
         

         //fetch data with eager loading

         Task<PagedList<Rental>> GetRentals(RentalParams rentalParams);
         Task<Rental> GetRentalById(int id);
         Task<IEnumerable<Car>> GetCars();
         Task<Car> GetCarById(int id);
         Task<IEnumerable<Location>> GetLocations();
         Task<Location> GetLocationById(int id);


         






    }
}