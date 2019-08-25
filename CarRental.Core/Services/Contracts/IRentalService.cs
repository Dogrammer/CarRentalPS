using System;
using CarRental.Model.Models;

namespace CarRental.Core.Services
{
    public interface IRentalService
    {
         bool CarAvailable(Rental rental);
         bool DateValid(DateTime? startDate, DateTime? endDate);
         

    }
}