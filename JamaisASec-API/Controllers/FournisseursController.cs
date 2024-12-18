using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    public class FournisseursController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public FournisseursController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        [Route("[controller]/get/all")]
        public ActionResult GetAll()
        {

            var data = _context.Fournisseurs;

           
            

            return Ok(data);
        }

        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create([FromBody] Fournisseurs fournisseur)
        {
            _context.Fournisseurs.Add(fournisseur);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = fournisseur.ID }, fournisseur);
        }

    }
}
