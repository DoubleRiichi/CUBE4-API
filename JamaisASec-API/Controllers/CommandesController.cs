﻿using Microsoft.AspNetCore.Mvc;
using JamaisASec.Models;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace JamaisASec.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CommandesController : ControllerBase
    {
        private readonly JamaisASecDbContext _context;

        public CommandesController(JamaisASecDbContext context)
        {
            _context = context;
        }
  [HttpGet]
        [Route("get/all")]
        public ActionResult GetAll()
        {

            var data = from commande in _context.Commandes
                       join client in _context.Clients
                            on commande.Clients_ID equals client.ID into ClientGroup
                       from client in ClientGroup.DefaultIfEmpty()
                       join fournisseur in _context.Fournisseurs
                            on commande.Fournisseurs_id equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()
                       select new
                       {
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status,
                           client,
                           fournisseur
                       };


            if (data.Any()) {
                return Ok(data);
            }


            return NotFound();
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult GetById(int id)
        {
            var data = from commande in _context.Commandes
                       where commande.ID == id
                       join client in _context.Clients
                            on commande.Clients_ID equals client.ID into ClientGroup
                       from client in ClientGroup.DefaultIfEmpty()
                       join fournisseur in _context.Fournisseurs
                            on commande.Fournisseurs_id equals fournisseur.ID into fournisseurGroup
                       from fournisseur in fournisseurGroup.DefaultIfEmpty()
                       select new 
                       { 
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status,
                           client, 
                           fournisseur,
                       };


            if (data.Any())
            {
                return Ok(data);
            }


            return NotFound();
        }

        [HttpGet]
        [Route("get/byClient/{clientId}")]
        public ActionResult GetCommandesByClientId(int clientId)
        {
            var data = from commande in _context.Commandes
                       where commande.Clients_ID == clientId
                       select new
                       {
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status
                       };

            if (data.Any())
            {
                return Ok(data);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("get/byFournisseur/{fournisseurId}")]
        public ActionResult GetCommandesByFournisseurId(int fournisseurId)
        {
            var data = from commande in _context.Commandes
                       where commande.Fournisseurs_id == fournisseurId
                       select new
                       {
                           commande.ID,
                           commande.Reference,
                           commande.Date,
                           commande.Status
                       };

            if (data.Any())
            {
                return Ok(data);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Commandes commande)
        {
            if (commande == null)
            {
                return BadRequest("Commande data is null.");
            }

            try
            {
                _context.Commandes.Add(commande);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = commande.ID }, commande);
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Commandes commande)
        {
            if (commande == null || commande.ID != id)
            {
                return BadRequest();
            }

            var existingCommande = _context.Commandes.Find(id);
            if (existingCommande == null)
            {
                return NotFound();
            }

            existingCommande.Reference = commande.Reference;
            existingCommande.Date = commande.Date;
            existingCommande.Status = commande.Status;
            existingCommande.Clients_ID = commande.Clients_ID;
            existingCommande.Fournisseurs_id = commande.Fournisseurs_id;

            try
            {
                _context.Commandes.Update(existingCommande);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

        }

        [HttpPut]
        [Route("update/status/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] JsonElement data)
        {
            var existingCommande = _context.Commandes.Find(id);
            if (existingCommande == null)
            {
                return NotFound("Commande non trouvée.");
            }

            // Vérifie si le JSON contient bien une propriété "status"
            if (!data.TryGetProperty("Status", out var statusJson))
            {
                return BadRequest("Champ 'Status' manquant.");
            }

            try
            {
                var statusString = statusJson.GetString(); // Récupère le statut en string
                
                if (statusString == null)
                {
                    return BadRequest("Le champ 'Status' ne peut pas être vide");
                }
                existingCommande.Status = statusString;
                _context.SaveChanges();
                return Ok();
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne : {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var commande = _context.Commandes.Find(id);
            if (commande == null)
            {
                return NotFound();
            }

            try
            {
                _context.Commandes.Remove(commande);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500); // 500 = internal server error 
            }

        }
    }
}
