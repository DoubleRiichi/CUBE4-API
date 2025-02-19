using Microsoft.AspNetCore.Mvc;
using JamaisASec;
using JamaisASec.Models;
using System.Text.Json;
using JamaisASec_API.Models;


namespace JamaisASec_API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthController : Controller
    {
        private readonly JamaisASecDbContext _context;

        public AuthController(JamaisASecDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/[controller]/login")]
        public IActionResult Login([FromBody] Auth AuthDetail)
        {
            if(AuthDetail.Email == null || AuthDetail.Password == null)
            {
                return BadRequest(new
                {
                    client = (Clients) null,
                    error = "Email or Password can't be empty.",
                });
            }

            var targetClient = _context.Clients.FirstOrDefault(e => e.Mail == AuthDetail.Email);

            if (targetClient == null) {

                return Ok(new
                {
                    client = (Clients)null,
                    error = "Incorrect credentials"
                });
            }

            bool successfulLogin = BCrypt.Net.BCrypt.EnhancedVerify(AuthDetail.Password, targetClient.Mot_De_Passe);

            if (successfulLogin) {
                return Ok(new
                {
                    client = new
                    {
                        targetClient.ID,
                        targetClient.Nom,
                        targetClient.Adresse,
                        targetClient.Mail,
                        targetClient.Telephone,
                       
                    },
                    error = (string) null
                });
            } else
            {
                return Ok(new
                {
                    client = (Clients)null,
                    error = "Incorrect credentials"
                });
            }
        }



    }
}
