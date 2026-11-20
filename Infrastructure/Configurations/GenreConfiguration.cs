using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genres>
{
    public void Configure(EntityTypeBuilder<Genres> builder)
    {
        builder.ToTable("Genrs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
    }

}
