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
            var data = _context.Clients.ToList();
            return Ok(data);
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
            return Ok(client);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Clients client)
        {
            if (client == null)
            {
                return BadRequest("Client data is null.");
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = client.ID }, client);
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
            existingClient.Telephone = client.Telephone;

            _context.Clients.Update(existingClient);
            _context.SaveChanges();
            return NoContent();
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

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
