using Domain.Bookings;
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

        builder
            .HasOne(b => b.Plan)
            .WithMany()
            .HasForeignKey(b => b.PlanId)
            .IsRequired();
    }
}
