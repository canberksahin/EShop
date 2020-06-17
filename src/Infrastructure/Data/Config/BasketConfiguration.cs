using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasMany(x => x.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.BasketId)
                .IsRequired();

            builder.Property(x => x.BuyerId)
                .IsRequired()
                .HasMaxLength(256);

        }
    }
}
