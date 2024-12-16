using Microsoft.EntityFrameworkCore;
using JamaisASec.Models;


public class JamaisASecDbContext : DbContext
{
    public JamaisASecDbContext(DbContextOptions<JamaisASecDbContext> options) : base(options){ }

    public DbSet<Articles> Articles { get; set; }
    public DbSet<Articles> ArticleCommande { get; set; }

    public DbSet<Articles> Clients { get; set; }

    public DbSet<Articles> Commandes { get; set; }
    public DbSet<Articles> Familles { get; set; }
    public DbSet<Articles> Fournisseurs { get; set; }
    public DbSet<Articles> Maisons { get; set; }
}

