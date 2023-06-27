using Domain.Attractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
    public void Configure(EntityTypeBuilder<Attraction> builder)
    {
        builder.ToTable("Attractions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
            x => x.Value,
            value => new AttractionId(value))
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasMaxLength(50)
            .IsRequired();
    }
}
