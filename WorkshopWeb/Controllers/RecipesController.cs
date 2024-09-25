using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Data;
using Workshop.Server.DTOs.RecipeDTOs;
using Workshop.Server.Entity;
using Workshop.Server.Mapper;

namespace Workshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly DataContext _context;

        public RecipesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipe()
        {
            return await _context.Recipe
                .Select(x => x.ToRecipeDTO())
                .ToListAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            Recipe? recipe = await _context.Recipe.FindAsync(id);

            return recipe == null
                ? BadRequest() :
                Ok(recipe.ToRecipeDTO());
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutRecipe(UpgradeRecipeDTO recipe)
        {
            var existingRecipe = await _context.Recipe.FindAsync(recipe.id);

            if (existingRecipe is null)
            {
                return NotFound();
            }

            _context.Entry(existingRecipe)
                .CurrentValues
                .SetValues(recipe.ToEntity(recipe.id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostRecipe(AddRecipeDTO newRecipe)
        {
            Recipe recipe = newRecipe.ToEntity();

            _context.Recipe.Add(recipe);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _context.Recipe
                .Where(recipe => recipe.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }
    }
}
