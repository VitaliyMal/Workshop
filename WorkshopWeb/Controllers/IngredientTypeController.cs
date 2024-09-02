using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopWeb.Entity;

namespace WorkshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public IngredientTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Workshops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient_Type>>> GetIngredients()
        {
            return await _context.Ingredient_Type.ToListAsync();
        }

        // GET: api/Workshops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient_Type>> GetWorkshop(int id)
        {
            var workshop = await _context.Ingredient_Type.FindAsync(id);

            if (workshop == null)
            {
                return NotFound();
            }

            return workshop;
        }

        // PUT: api/Workshops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkshop(int id, Ingredient_Type workshop)
        {
            if (id != workshop.Id)
            {
                return BadRequest();
            }

            _context.Entry(workshop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(id))
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

        // POST: api/Workshops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient_Type>> PostWorkshop(Ingredient_Type workshop)
        {
            _context.Ingredient_Type.Add(workshop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkshop", new { id = workshop.Id }, workshop);
        }

        // DELETE: api/Workshops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkshop(int id)
        {
            var workshop = await _context.Ingredient_Type.FindAsync(id);
            if (workshop == null)
            {
                return NotFound();
            }

            _context.Ingredient_Type.Remove(workshop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkshopExists(int id)
        {
            return _context.Ingredient_Type.Any(e => e.Id == id);
        }
    }
}
