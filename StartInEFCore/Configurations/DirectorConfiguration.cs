using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StartInEFCore.Models;

namespace StartInEFCore.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder
            .HasKey(d => d.Id);

        builder
            .HasOne(d => d.MovieStudio)
            .WithOne(ms => ms.Director)
            .HasForeignKey<Director>(d => d.MoveStudioId);
    }
}
