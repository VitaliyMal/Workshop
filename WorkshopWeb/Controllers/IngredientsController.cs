using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.DTOs.IngredientDTOs;
using Workshop.Server.Mapper;
using WorkshopWeb.Entity;

namespace WorkshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly DataContext _context;

        public IngredientsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDTO>>> GetIngredient()
        {
            return await _context.Ingredient
                .Select(x => x.ToIngredientDTO())
                .ToListAsync();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDTO>> GetIngredient(int id)
        {
            Ingredient? ingredient = await _context.Ingredient.FindAsync(id);

            return ingredient == null
                ? BadRequest() :
                Ok(ingredient.ToIngredientDTO());
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, UpdateIngredientDTO ingredient)
        {
            var existingIngredient = await _context.Ingredient.FindAsync(id);

            if (existingIngredient is null)
            {
                return NotFound();
            }

            _context.Entry(existingIngredient)
                .CurrentValues
                .SetValues(ingredient.ToEntity(id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostIngredient(AddIngredientDTO newIngredient)
        {
            Ingredient ingredient = newIngredient.ToEntity();

            _context.Ingredient.Add(ingredient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _context.Ingredient
                .Where(ingredient => ingredient.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.Id == id);
        }
    }
}
