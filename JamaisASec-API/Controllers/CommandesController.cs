using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Linq;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CommandesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public CommandesController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {
            var data = _context.Commandes.ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var commande = _context.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }
            return Ok(commande);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Commandes commande)
        {
            if (commande == null)
            {
                return BadRequest("Commande data is null.");
            }

            _context.Commandes.Add(commande);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = commande.ID }, commande);
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Commandes commande)
        {
            if (commande == null || commande.ID != id)
            {
                return BadRequest();
            }

            var existingCommande = _context.Commandes.Find(id);
            if (existingCommande == null)
            {
                return NotFound();
            }

            existingCommande.Reference = commande.Reference;
            existingCommande.Date = commande.Date;
            existingCommande.Status = commande.Status;
            existingCommande.Clients_ID = commande.Clients_ID;
            existingCommande.Fournisseurs_ID = commande.Fournisseurs_ID;

            _context.Commandes.Update(existingCommande);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var commande = _context.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commandes.Remove(commande);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
