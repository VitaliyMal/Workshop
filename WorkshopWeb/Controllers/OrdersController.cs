using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.DTOs.OrderDTOs;
using Workshop.Server.Entity;
using Workshop.Server.Mapper;
using WorkshopWeb;

namespace Workshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrder()
        {
            return await _context.Order
                .Select(x => x.ToOrderDTO())
                .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            Order? order = await _context.Order.FindAsync(id);

            return order == null
                ? BadRequest() :
                Ok(order.ToOrderDTO());
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, UpgradeOrderDTO order)
        {
            var existingOrder = await _context.Order.FindAsync(id);

            if (existingOrder is null)
            {
                return NotFound();
            }

            _context.Entry(existingOrder)
                .CurrentValues
                .SetValues(order.ToEntity(id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOrder(AddOrderDTO newOrder)
        {
            Order order = newOrder.ToEntity();

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _context.Order
                .Where(order => order.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
