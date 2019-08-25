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
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : AppController
    {
        private readonly IRepository<User> _repo;

        public UsersController(IRepository<User> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repo.Get();
            
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return ApiOk(await _repo.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]User user)
        {
            return ApiOk(await _repo.Add(user));
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutUser(int id, [FromBody]User user)
        // {
        //     if (id != user.Id)
        //         return BadRequest();

        //     // _repo.Update(carCategory);
        //     return ApiOk(await _repo.Update(user));
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repo.GetById(id);

            return ApiOk(await _repo.Remove(user));
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Customer>> GetCustomer(int id)
        // {
        //     var customer = await _repo.GetById(id);

        //     if (customer == null)
        //         return NotFound();

        //     return Ok(customer);
        // }


        // [HttpPost]
        // public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        // {
        //     await _repo.Add(customer);
        //     await _repo.Save();

        //     return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Customer>> PutCustomer(int id, [FromBody]Customer customer)
        // {

        //     if ( id != customer.Id)
        //     {
        //         return BadRequest();
        //     }

        //      _repo.Update(customer);

        //     await _repo.Save();
            
        //     return NoContent();
        // }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult<Customer>> PatchCustomer([FromBody]JsonPatchDocument<Customer> customer, int id)
        // {

        //    await _repo.Patch(customer, id);

        //     await _repo.Save();            

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        // {
        //     var customer = await _repo.GetById(id);

        //     if (customer == null)
        //         return NotFound();

        //     await _repo.Remove(customer);
        //     await _repo.Save();

        //     return NoContent();

        // }        




        // private readonly CarRentalContext _context;
        // public CustomersController(CarRentalContext context)
        // {
        //     _context = context;
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        // {
        //     var customers = await _context.Customers.ToListAsync();

        //     if (customers == null)
        //         return NotFound();

        //     return customers;
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Customer>> GetCustomer(int id)
        // {
        //     var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        //     if (customer == null)
        //         return NotFound();

        //     return Ok(customer);
        // }


        // [HttpPost]
        // public async Task<ActionResult<Customer>> PostCustomer([FromBody] Customer customer)
        // {
        //     await _context.Customers.AddAsync(customer);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<Customer>> PutCustomer(int id, [FromBody]Customer customer)
        // {

        //     if ( id != customer.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(customer).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCustomer(int id)
        // {
        //     var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        //     if (customer == null)
        //         return NotFound();

        //     _context.Customers.Remove(customer);
        //     await _context.SaveChangesAsync();

        //     return NoContent();

        // }

    }
}