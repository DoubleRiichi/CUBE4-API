using Microsoft.EntityFrameworkCore;

namespace JamaisASec_API;


public class JamaisASecDbContext : DbContext
{
    public JamaisASecDbContext(DbContextOptions<JamaisASecDbContext> options) : base(options){ }

    public DbSet<Articles> Articles { get; set; }
}

public class Articles
{
    public int ID { get; set; }
    public string Nom { get; set; }
    public int Quantité { get; set; }
    public string Image { get; set; }
    public int Prix_unitaire { get; set; }
    public int Colisage { get; set; }
    public int Quantité_Min { get; set; }
    public int Année { get; set; }
    public string Description { get; set; }

    public int Familles_ID { get; set; }
    public int Maisons_ID { get; set; }

}