using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamaisASec.Models;

namespace JamaisASec_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FournisseursController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public FournisseursController(JamaisASecDbContext context)
        {
            _context = context;
        }

        // GET: api/Fournisseurs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Fournisseurs.ToListAsync();
            return Ok(data);
        }
    }
}
