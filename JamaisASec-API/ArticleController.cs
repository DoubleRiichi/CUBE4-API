using Microsoft.AspNetCore.Mvc;
using System.Text.Json;



namespace JamaisASec_API



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
            var options = new JsonSerializerOptions { WriteIndented = true };
            var data = _context.Articles;

            string dataJson = JsonSerializer.Serialize(data.ToList(),options);
            

            return Ok(dataJson);
        }

        public IActionResult Create([FromBody] Articles entity)
        {
            _context.Articles.Add(entity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = entity.ID }, entity);
        }

    }
}
