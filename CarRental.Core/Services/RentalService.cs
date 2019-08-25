using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CarRental.Core.Repositories;
using CarRental.Infrastructure.DB;
using CarRental.Model.Models;
using CarRental.Shared.Extensions;

namespace CarRental.Core.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Rental> _repository;
        private readonly RentalContext _context;
        public RentalService(IRepository<Rental> repository, RentalContext context)
        {
            _context = context;
            _repository = repository;

        }
        public bool CarAvailable(Rental rental)
        {
            return _context
               .Rentals
               .Where(c => rental.StartDate.InRange(c.StartDate, c.EndDate)
                      || rental.EndDate.InRange(c.StartDate, c.EndDate)
                      || c.StartDate.InRange(rental.StartDate, rental.EndDate)
                      || c.EndDate.InRange(rental.StartDate, rental.EndDate))
               .FirstOrDefault(x => x.CarId == rental.CarId) == null;
        }


        public bool DateValid(DateTime? startDate, DateTime? endDate)
        {
            if (startDate > endDate)
                return false;

            return true;
        }


        // public bool FindFree(Rental rental)
        // {
        //      return _context
        //         .Rentals
        //         .Where(c => rental.StartDate.InRange(c.StartDate, c.EndDate)
        //                || rental.EndDate.InRange(c.StartDate, c.EndDate)
        //                || c.StartDate.InRange(rental.StartDate, rental.EndDate)
        //                || c.EndDate.InRange(rental.StartDate, rental.EndDate))
        //         .FirstOrDefault(x => x.CarId == rental.CarId) == null;
        // }

    }
}