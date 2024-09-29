using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StartInEFCore.Models;

namespace StartInEFCore.Configurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder
            .HasKey(f => f.Id);

        builder
            .HasOne(f => f.MovieStudio)
            .WithMany(ms => ms.Films)
            .HasForeignKey(f => f.MoveStudioId);
    }
}
