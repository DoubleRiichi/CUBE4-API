using Microsoft.EntityFrameworkCore;
using JamaisASec.Models;


public class JamaisASecDbContext : DbContext
{
    public JamaisASecDbContext(DbContextOptions<JamaisASecDbContext> options) : base(options){ }

    public DbSet<Articles> Articles { get; set; }
    public DbSet<ArticlesCommandes> ArticlesCommandes { get; set; }

    public DbSet<Clients> Clients { get; set; }

    public DbSet<Commandes> Commandes { get; set; }
    public DbSet<Familles> Familles { get; set; }
    public DbSet<Fournisseurs> Fournisseurs { get; set; }

    public DbSet<Maisons> Maisons { get; set; }
}

