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

            var data = from article in _context.Articles
                       join famille in _context.Familles
                            on article.Familles_ID equals famille.ID into familleGroup
                       from famille in familleGroup.DefaultIfEmpty()
                       join maison in _context.Maisons
                       on article.Maisons_ID equals maison.ID into maisonGroup
                       from maison in maisonGroup.DefaultIfEmpty()
                       join fournisseur in _context.Fournisseurs
                       on article.Fournisseurs_ID equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()                   
                       select new
                       {
                           article.ID,
                           article.Nom,
                           article.Description,
                           article.Quantite,
                           article.Quantite_Min,
                           article.Colisage,
                           article.Prix_unitaire,
                           article.Annee,
                           article.Image,
                           famille,
                           maison,
                           fournisseur
                       };

            if (data.Any()) {
                return Ok(data);
            }


            return NotFound();
        }

        [HttpGet]
        [Route("[controller]/get/{id}")]
        public ActionResult GetById(int id)
        {


            var data = from article in _context.Articles
                       where article.ID == id
                       join famille in _context.Familles
                            on article.Familles_ID equals famille.ID into familleGroup
                       from famille in familleGroup.DefaultIfEmpty()
                       join maison in _context.Maisons
                       on article.Maisons_ID equals maison.ID into maisonGroup
                       from maison in maisonGroup.DefaultIfEmpty()
                       join fournisseur in _context.Fournisseurs
                       on article.Fournisseurs_ID equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()
                       select new
                       {
                           article.ID,
                           article.Nom,
                           article.Description,
                           article.Quantite,
                           article.Quantite_Min,
                           article.Colisage,
                           article.Prix_unitaire,
                           article.Annee,
                           article.Image,
                           famille,
                           maison,
                           fournisseur
                       };


            if (data.Any())
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
            existingArticle.Fournisseurs_ID = article.Fournisseurs_ID;

            try {

                _context.Articles.Update(existingArticle);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500); // 500 = internal server error 
            }

        }


        [HttpPost]
        [Route("[controller]/create")]
        public IActionResult Create([FromBody] Articles article)
        {
            try {

                //if (article.Fournisseurs_ID == 0)
                //{
                //    article.Fournisseurs_ID = 1; 
                //}

                _context.Articles.Add(article);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAll), new { id = article.ID }, article);
            }
            catch (Exception ex) {
                return StatusCode(500); // 500 = internal server error 
            }

        }


        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }


            try {
                _context.Articles.Remove(article);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500); // 500 = internal server error 
            }
 
        }

    }

}
