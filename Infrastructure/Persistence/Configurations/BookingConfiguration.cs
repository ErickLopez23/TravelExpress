using Domain.Bookings;
using Domain.Plans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new BookingId(value));

        builder
            .HasOne<Plan>()
            .WithMany()
            .HasForeignKey(x => x.PlanId);

        builder.OwnsOne(x => x.Customer, customerBuilder =>
        {
            customerBuilder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            customerBuilder
                .Property(x => x.Phone)
                .HasMaxLength(9)
                .IsRequired();

            customerBuilder
                .Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();
        });
    }
}
