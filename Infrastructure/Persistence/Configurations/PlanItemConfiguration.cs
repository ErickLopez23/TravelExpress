using Domain.Attractions;
using Domain.Plans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PlanItemConfiguration : IEntityTypeConfiguration<PlanItem>
{
    public void Configure(EntityTypeBuilder<PlanItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
            x => x.Value,
            value => new PlanItemId(value))
            .IsRequired();

        builder
            .HasOne<Attraction>()
            .WithMany()
            .HasForeignKey(x => x.AttractionId);
    }
}
