using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Core.Repositories;
using CarRental.Model;
using CarRental.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarCategoriesController : AppController
    {
        private readonly IRepository<CarCategory> _repo;

        public CarCategoriesController(IRepository<CarCategory> repo)
        {
            _repo = repo;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<CarCategory>>> GetCarCategories()
        // {
        //     // var carCategories = await _context.CarCategories.ToListAsync();

        //     // return Ok(carCategories);
        //     var categories = await _repo.Get();

        //     if (categories == null)
        //         return NotFound();

        //     return Ok(categories);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<CarCategory>> GetCarCategory(int id)
        // {
        //     var category = await _repo.GetById(id);

        //     if (category == null)
        //         return NotFound();

        //     return Ok(category);
        // }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCategory>>> GetCarCategories()
        {
            // var carCategories = await _context.CarCategories.ToListAsync();

            // return Ok(carCategories);
            var categories = await _repo.Get();

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarCategory(int id)
        {
            return ApiOk(await _repo.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostCarCategory([FromBody]CarCategory category)
        {
            return ApiOk(await _repo.Add(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCategory(int id, [FromBody]CarCategory carCategory)
        {
            if (id != carCategory.Id)
                return BadRequest();

            // _repo.Update(carCategory);
            return ApiOk(await _repo.Update(carCategory));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var category = await _repo.GetById(id);

            return ApiOk(await _repo.Remove(category));
        }




        // [HttpPost]
        // public async Task<ActionResult<CarCategory>> PostCarCategory([FromBody] CarCategory category)
        // {
        //     await _repo.Add(category);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetCarCategory), new { id = category.Id }, category);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<CarCategory>> PutCarCategory(int id, [FromBody]CarCategory carCategory)
        // {
        //     if (id != carCategory.Id)
        //         return BadRequest();

        //     _repo.Update(carCategory);
        //     await _repo.Save();

        //     return NoContent();
        // }

        [HttpPatch("{id}")]
        public async Task<ActionResult<City>> PatchCarCategory([FromBody]JsonPatchDocument<CarCategory> carCategory, int id)
        {
            await _repo.Patch(carCategory, id);

            await _repo.Save();

            return NoContent();
        }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCarCategory(int id)
        // {
        //     var category = await _repo.GetById(id);

        //     if (category == null)
        //         return NotFound();

        //     await _repo.Remove(category);
        //     await _repo.Save();

        //     return NoContent();
        // }




        // private readonly CarRentalContext _context;
        // public CarCategoriesController(CarRentalContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<CarCategory>>> GetCarCategories()
        // {
        //     var categories = await _context.CarCategories.ToListAsync();

        //     if (categories == null)
        //         return NotFound();

        //     return Ok(categories);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<CarCategory>> GetCarCategory(int id)
        // {
        //     var category = await _context.CarCategories.FindAsync(id);

        //     if (category == null)
        //         return NotFound();

        //     return Ok(category);
        // }


        // [HttpPost]
        // public async Task<ActionResult<CarCategory>> PostCarCategory([FromBody] CarCategory category)
        // {
        //     await _context.CarCategories.AddAsync(category);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetCarCategory), new { id = category.Id }, category);
        // }

        //   [HttpPut("{id}")]
        // public async Task<ActionResult<CarCategory>> PutCarCategory(int id, [FromBody]CarCategory carCategory)
        // {
        //     if ( id != carCategory.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(carCategory).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCarCategory(int id)
        // {
        //     var category = await _context.CarCategories.FirstOrDefaultAsync(x => x.Id == id);

        //     if (category == null)
        //         return NotFound();

        //     _context.CarCategories.Remove(category);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}