#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlamningsupgiftApi;
using InlamningsupgiftApi.Models.Entities;
using InlamningsupgiftApi.Models;
using InlamningsupgiftApi.Filter;

namespace InlamningsupgiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[UseApiKey]
    public class CustomerController : ControllerBase
    {
        private readonly SqlContext _context;

        public CustomerController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var items = new List<Customer>();

            foreach (var item in await _context.Customers.ToListAsync())
                items.Add(new Customer(item.Id, item.FirstName, item.LastName, item.Email));

            return items;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            return new Customer(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var customerEntity = await _context.Customers.FindAsync(model.Id);
            if (customerEntity == null)
                return NotFound();

            customerEntity.FirstName = model.FirstName;
            customerEntity.LastName = model.LastName;
            customerEntity.Email = model.Email;
            customerEntity.Password = model.Password;

            _context.Entry(customerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomerEntity(CustomerCreateModel model)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == model.Email))
                return Conflict("A customer with the same email address already exists.");

            var customerEntity = new CustomerEntity(model.FirstName, model.LastName, model.Email, model.Address, model.City, model.ZipCode, model.Password);
            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCustomerEntity", new { id = customerEntity.Id }, new Customer(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email,customerEntity.Address, customerEntity.City, customerEntity.ZipCode));
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            customerEntity.FirstName = "";
            customerEntity.LastName = "";
            customerEntity.Email = "";
            customerEntity.Password = "";

            _context.Entry(customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool CustomerEntityExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

