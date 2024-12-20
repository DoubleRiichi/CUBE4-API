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

            var data = from articlecommande in _context.ArticlesCommandes
                       join article in _context.Articles
                            on articlecommande.Articles_ID equals article.ID into ArticleGroup
                       from article in ArticleGroup.DefaultIfEmpty()
                       join commande in _context.Commandes
                       on articlecommande.Commandes_ID equals commande.ID into commandeGroup
                       from commande in commandeGroup.DefaultIfEmpty()
                       select new { articlecommande, article, commande};



            if(data.Any())
            {
                return Ok(data);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("[controller]/get/{id}")]
        public ActionResult GetById(int id)
        {

            var data = from articlecommande in _context.ArticlesCommandes
                       where articlecommande.ID == id
                       join article in _context.Articles
                            on articlecommande.Articles_ID equals article.ID into ArticleGroup
                       from article in ArticleGroup.DefaultIfEmpty()
                       join commande in _context.Commandes
                       on articlecommande.Commandes_ID equals commande.ID into commandeGroup
                       from commande in commandeGroup.DefaultIfEmpty()
                       select new { articlecommande, article, commande };



            if (data.Any())
            {
                return Ok(data);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create([FromBody] ArticlesCommandes articlecommande)
        {
            try
            {
                _context.ArticlesCommandes.Add(articlecommande);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAll), new { id = articlecommande.ID }, articlecommande);
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
            var articlecommande = _context.ArticlesCommandes.Find(id);
            if (articlecommande == null) {
                return NotFound();
            }

            try {
                _context.ArticlesCommandes.Remove(articlecommande);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500); // 500 = internal server error 
            }


        }



    }
}
