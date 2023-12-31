﻿using Domain.Plans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
            x => x.Value,
            value => new PlanId(value))
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Departure)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.Return)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18, 4)")
            .IsRequired();

        builder
            .HasMany(e => e.PlanItems)
            .WithOne()
            .HasForeignKey(pi => pi.PlanId)
            .IsRequired();
    }
}
