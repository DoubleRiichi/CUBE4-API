using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Text.Json;
using System.Linq;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class MaisonsController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public MaisonsController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {
            var data = _context.Maisons.ToList();

            if(data.Any()) { 
                return Ok(data);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var maison = _context.Maisons.Find(id);
            if (maison == null)
            {
                return NotFound();
            }
            return Ok(maison);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Maisons maison)
        {
            if (maison == null)
            {
                return BadRequest("Maison data is null.");
            }

            try
            {
                _context.Maisons.Add(maison);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = maison.ID }, maison);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }


        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Maisons maison)
        {
            if (maison == null || maison.ID != id)
            {
                return BadRequest();
            }

            var existingMaison = _context.Maisons.Find(id);
            if (existingMaison == null)
            {
                return NotFound();
            }

            existingMaison.Nom = maison.Nom;

            try
            {
                _context.Maisons.Update(existingMaison);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var maison = _context.Maisons.Find(id);
            if (maison == null)
            {
                return NotFound();
            }

            try
            {
                _context.Maisons.Remove(maison);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

        }
    }
}
