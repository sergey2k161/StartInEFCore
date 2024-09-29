using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StartInEFCore.Models;

namespace StartInEFCore.Configurations;

public class MovieStudioConfiguration : IEntityTypeConfiguration<MovieStudio>
{
    public void Configure(EntityTypeBuilder<MovieStudio> builder)
    {
        builder
            .HasKey(ms => ms.Id);

        builder
            .HasOne(ms => ms.Director)
            .WithOne(ms => ms.MovieStudio)
            .HasForeignKey<MovieStudio>(ms => ms.DirectorId);  

        builder
            .HasMany(ms => ms.Films)
            .WithOne(f => f.MovieStudio)
            .HasForeignKey(f => f.MoveStudioId);

        builder
            .HasMany(ms => ms.Actors)
            .WithMany(a => a.MovieStudios);
    }
}
