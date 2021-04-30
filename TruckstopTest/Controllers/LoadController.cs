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

        // GET: LoadController
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

        // GET: LoadController/Details/5
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

        // POST: LoadController/Create
        [HttpPost]
        public async Task<ActionResult<Load>> PostLoadItem(Load load)
        {
            _context.Loads.Add(load);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoadDetails), new { id = load.Id }, load);
        }

        // POST: LoadController/Delete/5
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

    // GET: LoadController/Edit/5
    /*public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: LoadController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: LoadController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }*/
}
}
