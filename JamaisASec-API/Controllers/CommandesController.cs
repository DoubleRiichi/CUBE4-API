using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public CommandesController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _context.Commandes;

           
            

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Commandes commande)
        {
            _context.Commandes.Add(commande);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = commande.ID }, commande);
        }

    }
}
