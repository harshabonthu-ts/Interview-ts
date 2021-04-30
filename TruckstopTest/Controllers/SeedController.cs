using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckstopTest.Context;

namespace TruckstopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : Controller
    {
        private readonly LoadsContext _context;
        public SeedController(LoadsContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<int>> SeedLoads()
        {
            _context.SeedData();

            return await _context.Loads.CountAsync();
        }
    }
}
