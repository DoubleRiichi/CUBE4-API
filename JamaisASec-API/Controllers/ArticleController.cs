using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



namespace JamaisASec.Controllers



{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public ArticlesController(JamaisASecDbContext context)

        {
            _context = context;


        }
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _context.Articles;

           
            

            return Ok(data);
        }

        public IActionResult Create([FromBody] Articles entity)
        {
            _context.Articles.Add(entity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = entity.ID }, entity);
        }

    }
}
