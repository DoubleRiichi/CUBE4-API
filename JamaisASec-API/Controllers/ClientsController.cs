using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Linq;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public ClientsController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {
            //Pour omettre le champs "mot_de_passe" par soucis de sécurité.
            var data = _context.Clients.Select(client => new
            {
                client.ID,
                client.Nom,
                client.Adresse,
                client.Mail,
                client.Telephone
            }).ToList();


            if(data.Any()) {
                return Ok(data);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                client.ID,
                client.Nom,
                client.Adresse,
                client.Mail,
                client.Telephone,

            });
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Clients client)
        {
            if (client == null)
            {
                return BadRequest("Client data is null.");
            }

            try
            {
                client.Mot_De_Passe = BCrypt.Net.BCrypt.EnhancedHashPassword(client.Mot_De_Passe);
                _context.Clients.Add(client);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = client.ID }, client);
            } catch (Exception ex)
            {

                return StatusCode(500);
            }

        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Clients client)
        {
            if (client == null || client.ID != id)
            {
                return BadRequest();
            }

            var existingClient = _context.Clients.Find(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Nom = client.Nom;
            existingClient.Adresse = client.Adresse;
            existingClient.Mail = client.Mail;
            existingClient.Mot_De_Passe = BCrypt.Net.BCrypt.EnhancedHashPassword(client.Mot_De_Passe);
            existingClient.Telephone = client.Telephone;

            try {
                _context.Clients.Update(existingClient);
                _context.SaveChanges();
                return Ok();
            } catch (Exception ex) {
                return StatusCode(500); // 500 = internal server error 
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            try
            {
               _context.Clients.Remove(client);
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
