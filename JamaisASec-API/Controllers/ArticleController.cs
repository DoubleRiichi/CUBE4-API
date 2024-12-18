using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;



    namespace JamaisASec.Controllers



{
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;


        public ArticlesController(JamaisASecDbContext context)

        {
            _context = context;


        }

        [HttpGet]
        [Route("[controller]/get/all")]
        public ActionResult GetAll()
        {

            var data = _context.Articles;

           
            

            return Ok(data);
        }

        [HttpGet]
        [Route("[controller]/get/{id}")]
        public ActionResult GetById(int id)
        {

            var data = _context.Articles.Find(id);

            if(data != null)
            {
                return Ok(data);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("[controller]/update/{id}")]
        public ActionResult Update([FromBody] Articles article, int id)
        {

            if (article == null || article.ID != id)
            {
                return BadRequest();
            }

            var existingArticle = _context.Articles.Find(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Nom = article.Nom;
            existingArticle.Quantite = article.Quantite;
            existingArticle.Quantite_Min = article.Quantite_Min;
            existingArticle.Image = article.Image;
            existingArticle.Prix_unitaire = article.Prix_unitaire;
            existingArticle.Colisage = article.Colisage;
            existingArticle.Quantite_Min = article.Quantite_Min;
            existingArticle.Annee = article.Annee;
            existingArticle.Description = article.Description;
            existingArticle.Familles_ID = article.Familles_ID;
            existingArticle.Maisons_ID = article.Maisons_ID;



            _context.Articles.Update(existingArticle);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create([FromBody] Articles article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = article.ID }, article);
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
