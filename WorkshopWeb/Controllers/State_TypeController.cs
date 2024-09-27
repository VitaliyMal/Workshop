using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Data;
using Workshop.Server.DTOs.State_TypeDTOs;
using Workshop.Server.Entity;
using Workshop.Server.Mapper;
using WorkshopWeb.Entity;

namespace Workshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class State_TypeController : ControllerBase
    {
        private readonly DataContext _context;

        public State_TypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/State_Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State_TypeDTO>>> GetState_Type()
        {
            return await _context.State_Type
                .Select(x => x.ToState_TypeDTO())
                .ToListAsync();
        }

        // GET: api/State_Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State_TypeDTO>> GetState_Type(int id)
        {
            State_Type? state_Type = await _context.State_Type.FindAsync(id);

            return state_Type == null
                ? BadRequest() :
                Ok(state_Type.ToState_TypeDTO());
        }

        // PUT: api/State_Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutState_Type(UpgradeState_TypeDTO state_Type)
        {
            var existingState_Type = await _context.State_Type.FindAsync(state_Type.id);

            if (existingState_Type is null)
            {
                return NotFound();
            }

            _context.Entry(existingState_Type)
                .CurrentValues
                .SetValues(state_Type.ToEntity(state_Type.id));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/State_Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostState_Type(AddState_TypeDTO newState_Type)
        {
            State_Type state_Type = newState_Type.ToEntity();

            _context.State_Type.Add(state_Type);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/State_Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState_Type(int id)
        {
            await _context.State_Type
                .Where(state_Type => state_Type.Id == id)
                .ExecuteDeleteAsync();

            return NoContent();
        }

        private bool State_TypeExists(int id)
        {
            return _context.State_Type.Any(e => e.Id == id);
        }
    }
}
