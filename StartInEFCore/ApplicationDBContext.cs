using Microsoft.EntityFrameworkCore;
using StartInEFCore.Configurations;
using StartInEFCore.Models;

namespace StartInEFCore;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
{
    public DbSet<Director> Directors { get; set; }
    public DbSet<MovieStudio> MovieStudios { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorConfiguration());
        modelBuilder.ApplyConfiguration(new FilmConfiguration());
        modelBuilder.ApplyConfiguration(new MovieStudioConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
