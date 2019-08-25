using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.DataAnnotations;
using CarRental.Core.Repositories;
using CarRental.Model.Models;
using CarRental.Core.Services;
using CarRental.Core.Helpers;
using CarRental.API.Controllers;

namespace CarRentalApp.Controllers
{
    // public static class DateTimeExtensions
    // {
    //     public static bool InRange(this DateTime? dateToCheck, DateTime? startDate, DateTime? endDate)
    //     {
    //             return dateToCheck >= startDate && dateToCheck < endDate;
    //     }
    // }

    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : AppController
    {
        private readonly IRepository<Rental> _repo;
        private readonly IRentalService _service;

        public RentalsController(IRepository<Rental> repo, IRentalService service)
        {
            _service = service;
            _repo = repo;

        }


        [HttpGet]
        public async Task<ActionResult> GetRentals([FromQuery]RentalParams rentalParams)
        {
            var rentals = await _repo.GetRentals(rentalParams);

            if (rentals == null)
                return NotFound();

            Response.AddPagination(rentals.CurrentPage, rentals.PageSize,
                rentals.TotalCount, rentals.TotalPages);

            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRental(int id)
        {
            return ApiOk(await _repo.GetRentalById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostRental([FromBody]Rental rental)
        {
            return ApiOk(await _repo.Add(rental));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, [FromBody]Rental rental)
        {
            if (id != rental.Id)
                return BadRequest();

            // _repo.Update(carCategory);
            return ApiOk(await _repo.Update(rental));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _repo.GetRentalById(id);

            return ApiOk(await _repo.Remove(rental));
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Rental>> GetRental(int id)
        // {
        //     var rental = await _repo.GetRentalById(id);

        //     if (rental == null)
        //         return NotFound();

        //     return Ok(rental);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Rental>> PostRental([FromBody]Rental rental)
        // {
        //     if (!_service.DateValid(rental.StartDate, rental.EndDate))
        //         return BadRequest("EndDate should be greater than StartDate !");
            
        //     if (!_service.CarAvailable(rental))
        //         return BadRequest("Car is not available!");


        //     await _repo.Add(rental);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetRentals), new { id = rental.Id }, rental);

        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Rental>> PutRental(int id, [FromBody]Rental rental)
        // {
        //     if (id != rental.Id || !_service.DateValid(rental.StartDate, rental.EndDate))
        //         return BadRequest();
            
        //     if (!_service.CarAvailable(rental))
        //         return BadRequest("Car is not available!");

        //     _repo.Update(rental);
        //     await _repo.Save();

        //     return NoContent();
        // }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult<Rental>> PatchRental([FromBody]JsonPatchDocument<Rental> rental, int id)
        // {

        //     await _repo.Patch(rental, id);

        //     await _repo.Save();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Rental>> DeleteRental(int id)
        // {
        //     var rental = await _repo.GetRentalById(id);

        //     if(rental == null)
        //         return NotFound("rental not found");
            
        //     await _repo.Remove(rental);

        //     return NoContent();
        // }

        // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        // {
        //     if (StartDate > EndDate)
        //     {
        //         yield return new ValidationResult("start date must be less than the end date!", new [] { "ConfirmEmail" });
        //     }
        }
        // private readonly CarRentalContext _context;
        // public RentalsController(CarRentalContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        // {
        //     var rentals = await _context.Rentals.ToListAsync();

        //     return Ok(rentals);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Rental>> GetRental(int id)
        // {
        //     var rental = await _context.Rentals
        //         .Include(l => l.PickUpLocation)
        //         .Include(d => d.DropOffLocation)
        //         .Include(c => c.Customer)
        //         .Include(r => r.Car)
        //         .FirstOrDefaultAsync(x => x.Id == id);

        //     if (rental == null)
        //         return NotFound();

        //     return Ok(rental);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Rental>> PostRental([FromBody]Rental rental)
        // {
        //     //ako je reservedCar == null onda znaci da datumi pasu
        //     //vraca objekt koji se ne conflikta sa intervalima, ako nema nista u njemu onda je BadRequest
        //     //ako ima nesto u njemu jos provjeri dali slucajno taj objekt nije zaokruzio taj interval datuma    
        //     var reservedCar = await _context
        //         .Rentals
        //         .Where( c => rental.StartDate.InRange(c.StartDate,c.EndDate) 
        //                 || rental.EndDate.InRange(c.StartDate, c.EndDate) 
        //                 || c.StartDate.InRange(rental.StartDate,rental.EndDate)
        //                 || c.EndDate.InRange(rental.StartDate, rental.EndDate))
        //         .FirstOrDefaultAsync(x => x.CarId == rental.CarId);


        //     if (rental.StartDate > rental.EndDate)
        //     {
        //         return BadRequest("Pocetni datum mora biti manji od zavrsnog datuma!");
        //     }


        //     if (reservedCar != null)
        //         return BadRequest("Car is not available in that period of time.");


        //     await _context.Rentals.AddAsync(rental);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetRentals), new { id = rental.Id }, rental);

        // }

        // // [AcceptVerbs("Post")]
        // // public ActionResult<bool> VerifyDates(DateTime startDate, DateTime endDate)
        // // {
        // //     if (startDate > endDate)
        // //         return BadRequest("Pocetni datum ne moze biti veći od Završnog datuma.");

        // //     return Ok(true);
        // // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Rental>> PutRental(int id, [FromBody]Rental rental)
        // {
        //     if ( id != rental.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(rental).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteRental(int id)
        // {
        //     var rental = await _context.Rentals.Include(p => p.PickUpLocation)
        //                                        .Include(d => d.DropOffLocation)
        //                                        .Include(c => c.Customer)
        //                                        .Include(c => c.Car)
        //                                        .FirstOrDefaultAsync(x => x.Id == id);

        //     if (rental == null)
        //         return NotFound();

        //     _context.Rentals.Remove(rental);
        //     await _context.SaveChangesAsync();

        //     return NoContent();

        // }
    }
