using System.Collections.Generic;
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
    public class CitiesController : AppController
    {
        private readonly IRepository<City> _repo;

        public CitiesController(IRepository<City> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _repo.Get();

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            return ApiOk(await _repo.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody]City city)
        {
            return ApiOk(await _repo.Add(city));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, [FromBody]City city)
        {
            if (id != city.Id)
                return BadRequest();

            // _repo.Update(carCategory);
            return ApiOk(await _repo.Update(city));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _repo.GetById(id);

            return ApiOk(await _repo.Remove(city));
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<City>> GetCity(int id)
        // {
        //     var city = await _repo.GetById(id);

        //     if (city == null)
        //         return NotFound();

        //     return Ok(city);
        // }

        // [HttpPost]
        // public async Task<ActionResult<City>> PostCity([FromBody] City city)
        // {
        //     await _repo.Add(city);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetCities), new { id = city.Id }, city);
        // }

        //  [HttpPut("{id}")]
        // public async Task<ActionResult<City>> PutCity(int id, [FromBody]City city)
        // {
        //     if ( id != city.Id)
        //         return BadRequest();
            
        //     _repo.Update(city);
            
        //     await _repo.Save();

        //     return NoContent();
        // }

        // //basically used for soft delete
        // [HttpPatch("{id}")]
        // public ActionResult<City> PatchCity([FromBody]JsonPatchDocument<City> city, int id)
        // {
            
        //     _repo.Patch(city, id);

        //     _repo.Save();            

        //     return NoContent();
        // }


        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteCity(int id)
        // {
        //     var city = await _repo.GetById(id);

        //     if (city == null)
        //         return NotFound();

        //     await _repo.Remove(city);
        //     await _repo.Save();

        //     return NoContent();
        // }














        //     private readonly CarRentalContext _context;
        //     public CitiesController(CarRentalContext context)
        //     {
        //         _context = context;

        //     }

        //     [HttpGet]
        //     public async Task<ActionResult<IEnumerable<City>>> GetCities()
        //     {
        //         return await _context.Cities.ToListAsync();
        //     }

        //     [HttpGet("{id}")]
        //     public async Task<ActionResult<City>> GetCity(int id)
        //     {
        //         var city = await _context.Cities.FindAsync(id);

        //         if (city == null)
        //             return NotFound();

        //         return Ok(city);
        //     }


        //     [HttpPost]
        //     public async Task<ActionResult<City>> PostCity([FromBody] City city)
        //     {
        //         await _context.Cities.AddAsync(city);
        //         await _context.SaveChangesAsync();

        //         return CreatedAtAction(nameof(GetCities), new { id = city.Id }, city);
        //     }

        //      [HttpPut("{id}")]
        //     public async Task<ActionResult<City>> PutCity(int id, [FromBody]City city)
        //     {
        //         if ( id != city.Id)
        //         {
        //             return BadRequest();
        //         }

        //         _context.Entry(city).State = EntityState.Modified;
        //         await _context.SaveChangesAsync();

        //         return NoContent();
        //     }

        //     //basically used for soft delete
        //     [HttpPatch("{id}")]
        //     public async Task<ActionResult<City>> PatchCity([FromBody]JsonPatchDocument<City> city, int id)
        //     {

        //         var cityToPatch = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

        //         if (cityToPatch == null)
        //         {
        //             return NotFound("city not found");
        //         }

        //         city.ApplyTo(cityToPatch);

        //         await _context.SaveChangesAsync();

        //         return NoContent();
        //     }


        //     [HttpDelete("{id}")]
        //     public async Task<IActionResult> DeleteCity(int id)
        //     {
        //         var city = await _context.Cities.FindAsync(id);

        //         if (city == null)
        //             return NotFound();

        //         _context.Cities.Remove(city);
        //         await _context.SaveChangesAsync();

        //         return NoContent();
        //     }



    }

}