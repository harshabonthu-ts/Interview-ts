using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckstopTest.Context;
using TruckstopTest.Models;

namespace TruckstopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController : Controller
    {
        private readonly LoadsContext _context;

        public LoadController(LoadsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoadDTO>>> GetLoads()
        {
            var loads = await _context.Loads.Select(x => LoadToDTO(x)).ToListAsync();

            if (loads == null)
            {
                return NotFound();
            }

            return loads;
        }

        private static LoadDTO LoadToDTO(Load load) => new LoadDTO
        {
            Id = load.Id
        };

        [HttpGet("{id}")]
        public async Task<ActionResult<Load>> GetLoadDetails(Guid id)
        {
            var load = await _context.Loads.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            return load;
        }

        [HttpPost]
        public async Task<ActionResult<Load>> PostLoadItem(Load load)
        {
            var existingLoad = await _context.Loads.FindAsync(load.Id);

            if (existingLoad != null)
            {
                return NotFound();
            }

            _context.Loads.Add(load);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoadDetails), new { id = load.Id }, load);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoad(Guid id)
        {
            var load = await _context.Loads.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }
            _context.Loads.Remove(load);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Add Update
    }
}
