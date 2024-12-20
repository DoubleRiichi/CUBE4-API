using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Linq;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class FamillesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public FamillesController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {
            var data = _context.Familles.ToList();

            if (data.Any()) {
                return Ok(data);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var famille = _context.Familles.Find(id);
            if (famille == null)
            {
                return NotFound();
            }
            return Ok(famille);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Familles famille)
        {
            if (famille == null)
            {
                return BadRequest("Famille data is null.");
            }

            _context.Familles.Add(famille);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = famille.ID }, famille);
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Familles famille)
        {
            if (famille == null || famille.ID != id)
            {
                return BadRequest();
            }

            var existingFamille = _context.Familles.Find(id);
            if (existingFamille == null)
            {
                return NotFound();
            }

            existingFamille.Nom = famille.Nom;

            _context.Familles.Update(existingFamille);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var famille = _context.Familles.Find(id);
            if (famille == null)
            {
                return NotFound();
            }

            _context.Familles.Remove(famille);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
