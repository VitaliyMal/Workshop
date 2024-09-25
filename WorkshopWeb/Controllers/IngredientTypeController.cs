//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Data;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using Workshop.Server.Mapper;
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

        // GET: api/Ingredient_Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient_TypeDTO>>> GetIngredient_Type()
        {
            return await _context.Ingredient_Type
                .Select(x => x.ToIngredient_TypeDTO())
                .ToListAsync();
        }

        // GET: api/Ingredient_Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient_TypeDTO>> GetIngredient_Type(int id)
        {
            Ingredient_Type? ingredient_Type = await _context.Ingredient_Type.FindAsync(id);

            return ingredient_Type == null
                ? BadRequest() :
                Ok(ingredient_Type.ToIngredient_TypeDTO());
        }

        // PUT: api/Ingredient_Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutIngredient_Type(UpgradeIngredient_TypeDTO ingredient_Type)
        {
            var existingIngredient_Type = await _context.Ingredient_Type.FindAsync(ingredient_Type.id);

            if (existingIngredient_Type is null)
            {
                return NotFound();
            }

            _context.Entry(existingIngredient_Type)
                .CurrentValues
                .SetValues(ingredient_Type.ToEntity(ingredient_Type.id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Ingredient_Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostIngredient_Type(AddIngredient_TypeDTO newIngredient_Type)
        {
            Ingredient_Type ingredient_Type = newIngredient_Type.ToEntity();

            _context.Ingredient_Type.Add(ingredient_Type);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Ingredient_Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient_Type(int id)
        {
            await _context.Ingredient_Type
                .Where(ingredient_Type => ingredient_Type.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool Ingredient_TypeExists(int id)
        {
            return _context.Ingredient_Type.Any(e => e.Id == id);
        }
    }
}
