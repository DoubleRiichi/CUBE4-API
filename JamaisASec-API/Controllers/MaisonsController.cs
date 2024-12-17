using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



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
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _context.Maisons;

           
            

            return Ok(data);
        }

        public IActionResult Create([FromBody] Maisons maison)
        {
            _context.Maisons.Add(maison);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = maison.ID }, maison);
        }

    }
}
