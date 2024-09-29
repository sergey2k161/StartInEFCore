using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StartInEFCore.Models;

namespace StartInEFCore.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasMany(a => a.MovieStudios)
            .WithMany(ms => ms.Actors);
    }
}