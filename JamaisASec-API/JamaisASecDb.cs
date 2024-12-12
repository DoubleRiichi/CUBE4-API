using Microsoft.EntityFrameworkCore;
using JamaisASec.Models;
namespace JamaisASec;


public class JamaisASecDbContext : DbContext
{
    public JamaisASecDbContext(DbContextOptions<JamaisASecDbContext> options) : base(options){ }

    public DbSet<Articles> Articles { get; set; }
    public DbSet<Clients> Clients  { get; set; }
    public DbSet<Commandes> Commendes { get; set; }
    public DbSet<Fournisseurs> Fournisseurs { get; set; }
}

