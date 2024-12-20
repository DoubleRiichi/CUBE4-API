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

            var data = from commande in _context.Commandes
                       join client in _context.Clients
                            on commande.Clients_ID equals client.ID into ClientGroup
                       from client in ClientGroup.DefaultIfEmpty()
                       join fournisseur  in _context.Fournisseurs
                       on commande.Fournisseurs_ID equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()
                       select new
                       {
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status,
                           client,
                           fournisseur
                       };


            if (data.Any()) {
                return Ok(data);
            }


            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var data = from commande in _context.Commandes
                       where commande.ID == id
                       join client in _context.Clients
                            on commande.Clients_ID equals client.ID into ClientGroup
                       from client in ClientGroup.DefaultIfEmpty()
                       join fournisseur in _context.Fournisseurs
                       on commande.Fournisseurs_ID equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()
                       select new 
                       { 
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status,
                           client, 
                           fournisseur 
                       };


            if (data.Any())
            {
                return Ok(data);
            }


            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Commandes commande)
        {
            if (commande == null)
            {
                return BadRequest("Commande data is null.");
            }

            try
            {
                _context.Commandes.Add(commande);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = commande.ID }, commande);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

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

            try
            {
                _context.Commandes.Update(existingCommande);
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
            var commande = _context.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            try
            {
                _context.Commandes.Remove(commande);
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
