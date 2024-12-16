using Microsoft.EntityFrameworkCore;
using JamaisASec_API.DB;
namespace JamaisASec_API;


public class JamaisASecDbContext : DbContext
{
    public JamaisASecDbContext(DbContextOptions<JamaisASecDbContext> options) : base(options){ }

    public DbSet<Articles> Articles { get; set; }
}

