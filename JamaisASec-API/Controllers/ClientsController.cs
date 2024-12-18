using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public ClientsController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        [Route("[controller]/get/all")]
        public ActionResult GetAll()
        {

            var data = _context.Clients;

           
            

            return Ok(data);
        }

        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create([FromBody] Clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = client.ID }, client);
        }

    }
}
