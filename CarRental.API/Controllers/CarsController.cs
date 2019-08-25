using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.API.Controllers;
using CarRental.Core.Repositories;
using CarRental.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : AppController
    {
        private readonly IRepository<Car> _repo;

        public CarsController(IRepository<Car> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _repo.GetCars();

            if (cars == null)
                return NotFound();

            return Ok(cars);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Car>> GetCar(int id)
        // {
        //     var car = await _repo.GetCarById(id);

        //     if (car == null)
        //         return NotFound();

        //     return Ok(car);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Car>> PostCar([FromBody]Car car)
        // {
        //     await _repo.Add(car);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetCars), new { id = car.Id }, car);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Car>> PutCar(int id, [FromBody]Car car)
        // {
        //     if ( id != car.Id)
        //     {
        //         return BadRequest();
        //     }

        //     await _repo.Update(car);
        //     await _repo.Save();

        //     return NoContent();
        // }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult<City>> PatchCar([FromBody]JsonPatchDocument<Car> car, int id)
        // {
        //     await _repo.Patch(car, id);

        //     await _repo.Save();            

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Car>> DeleteCar(int id)
        // {
        //     var car =  await _repo.GetCarById(id);

        //     if (car == null)
        //         return NotFound();
            
        //    await _repo.Remove(car);

        //     return NoContent();

        // }

        //appcontroller fore
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            return ApiOk(await _repo.GetCarById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostCar([FromBody]Car car)
        {
            return ApiOk(await _repo.Add(car));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, [FromBody]Car car)
        {
            if (id != car.Id)
                return BadRequest();

            // _repo.Update(carCategory);
            return ApiOk(await _repo.Update(car));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _repo.GetCarById(id);

            return ApiOk(await _repo.Remove(car));
        }







        // private readonly CarRentalContext _context;
        // public CarsController(CarRentalContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        // {
        //     var cars = await _context.Cars.ToListAsync();

        //     if (cars == null)
        //         return NotFound();
        //     return Ok(cars);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Car>> GetCar(int id)
        // {
        //     var car = await _context.Cars.Include(c => c.CarCategory).FirstOrDefaultAsync(x => x.Id == id);

        //     if (car == null)
        //         return NotFound();

        //     return Ok(car);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Car>> PostCar([FromBody]Car car)
        // {
        //     await _context.Cars.AddAsync(car);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetCars), new { id = car.Id }, car);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Car>> PutCar(int id, [FromBody]Car car)
        // {
        //     if ( id != car.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(car).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Car>> DeleteCar(int id)
        // {
        //     var car = await _context.Cars.Include(c => c.CarCategory).FirstOrDefaultAsync( x => x.Id == id);

        //     if (car == null)
        //         return NotFound();

        //     _context.Cars.Remove(car);
        //     await _context.SaveChangesAsync();

        //     return NoContent();

        // }





    }
}