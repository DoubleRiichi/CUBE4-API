using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Text.Json;
using System.Linq;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class FournisseursController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public FournisseursController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {
            var data = _context.Fournisseurs.ToList();
            if(data.Any()) { 
                return Ok(data);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var fournisseur = _context.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            return Ok(fournisseur);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Fournisseurs fournisseur)
        {
            if (fournisseur == null)
            {
                return BadRequest("Fournisseur data is null.");
            }

            try
            {
                _context.Fournisseurs.Add(fournisseur);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = fournisseur.ID }, fournisseur);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }


        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Fournisseurs fournisseur)
        {
            if (fournisseur == null || fournisseur.ID != id)
            {
                return BadRequest();
            }

            var existingFournisseur = _context.Fournisseurs.Find(id);
            if (existingFournisseur == null)
            {
                return NotFound();
            }

            existingFournisseur.Nom = fournisseur.Nom;
            existingFournisseur.Adresse = fournisseur.Adresse;
            existingFournisseur.Mail = fournisseur.Mail;
            existingFournisseur.Telephone = fournisseur.Telephone;
            existingFournisseur.SIRET = fournisseur.SIRET;

            try
            {
                _context.Fournisseurs.Update(existingFournisseur);
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
            var fournisseur = _context.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            try
            {
                _context.Fournisseurs.Remove(fournisseur);
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
