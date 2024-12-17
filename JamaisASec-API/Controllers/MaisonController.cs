using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamaisASec.Models;


namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaisonsController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public MaisonsController(JamaisASecDbContext context)
        {
            _context = context;
        }

        // GET: api/Maisons
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Maisons.ToListAsync();
            return Ok(data);
        }
    }
}
