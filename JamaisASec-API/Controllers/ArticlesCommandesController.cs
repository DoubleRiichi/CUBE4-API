using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    public class ArticlesCommandesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public ArticlesCommandesController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        [Route("[controller]/get/all")]
        public ActionResult GetAll()
        {

            var data = _context.ArticlesCommandes;

           
            

            return Ok(data);
        }

       /* public IActionResult Create([FromBody] ArticlesCommandesController articleCommande)
        {
            _context.ArticlesCommandes.Add(articleCommande);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = articleCommande.ID }, articleCommande);
        }*/

    }
}
