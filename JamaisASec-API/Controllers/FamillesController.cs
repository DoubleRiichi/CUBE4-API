using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    [Route("api/[controller]")]
    public class FamillesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public FamillesController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _context.Familles;

           
            

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Familles famille)
        {
            _context.Familles.Add(famille);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = famille.ID }, famille);
        }

    }
}
