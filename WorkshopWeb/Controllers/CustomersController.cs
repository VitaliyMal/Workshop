using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Data;
using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.Entity;
using Workshop.Server.Mapper;

namespace Workshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomer()
        {
            return await _context.Customer
                .Select(x => x.ToCustomerDTO())
                .ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            Customer? customer = await _context.Customer.FindAsync(id);

            return customer == null
                ? BadRequest() :
                Ok(customer.ToCustomerDTO());
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCustomer(UpgradeCustomerDTO customer)
        {
            var existingCustomer = await _context.Customer.FindAsync(customer.id);

            if (existingCustomer is null)
            {
                return NotFound();
            }

            _context.Entry(existingCustomer)
                .CurrentValues
                .SetValues(customer.ToEntity(customer.id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCustomer(AddCustomerDTO newCustomer)
        {
            Customer customer = newCustomer.ToEntity();

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _context.Customer
                .Where(customer => customer.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
