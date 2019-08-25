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
    public class LocationsController : AppController
    {
       
        private readonly IRepository<Location> _repo;

        public LocationsController(IRepository<Location> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _repo.GetLocations();
            if (locations == null)
                return NotFound();

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            return ApiOk(await _repo.GetLocationById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostLocation([FromBody]Location location)
        {
            return ApiOk(await _repo.Add(location));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, [FromBody]Location location)
        {
            if (id != location.Id)
                return BadRequest();

            // _repo.Update(carCategory);
            return ApiOk(await _repo.Update(location));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _repo.GetLocationById(id);

            return ApiOk(await _repo.Remove(location));
        }
                                                
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Location>> GetLocation(int id)
        // {
        //     var location = await _repo.GetLocationById(id);

        //     if (location == null)
        //         return NotFound();

        //     return Ok(location);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Location>> PostLocation([FromBody]Location location)
        // {

        //     await _repo.Add(location);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);

        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Location>> PutLocation(int id, [FromBody]Location location)
        // {
        //     if (id != location.Id)
        //         return BadRequest();

        //     _repo.Update(location);
        //     await _repo.Save();

        //     return NoContent();
        // }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult<Location>> PatchLocation([FromBody]JsonPatchDocument<Location> location, int id)
        // {

        //     await _repo.Patch(location, id);

        //     await _repo.Save();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteLocation(int id)
        // {
        //     var location = await _repo.GetLocationById(id);

        //     if(location == null)
        //         return NotFound("location not found!");

        //     await _repo.Remove(location);

        //     return NoContent();
        // }

        // private readonly CarRentalContext _context;
        // public LocationsController(CarRentalContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        // {
        //     var locations = await _context.Locations.ToListAsync();

        //     return Ok(locations);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Location>> GetLocation(int id)
        // {
        //     var location = await _context.Locations.Include(x => x.City).FirstOrDefaultAsync(l => l.Id == id);

        //     if (location == null)
        //         return NotFound();

        //     return Ok(location);
        // }

        // [HttpPost]
        // public async Task<ActionResult<Location>> PostLocation([FromBody]Location location)
        // {

        //     await _context.Locations.AddAsync(location);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);

        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Location>> PutLocation(int id, [FromBody]Location location)
        // {
        //     if ( id != location.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(location).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteLocation(int id)
        // {
        //     var location = await _context.Locations.Include(c => c.City).FirstOrDefaultAsync(x => x.Id == id);

        //     if (location == null)
        //         return NotFound();

        //     _context.Locations.Remove(location);
        //     await _context.SaveChangesAsync();

        //     return NoContent();

        // }


    }
}