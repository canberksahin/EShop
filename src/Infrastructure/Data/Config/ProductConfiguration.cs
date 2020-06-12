using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
     public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Photo)
                .IsRequired(false);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x=>x.CategoryId)
                .IsRequired();

            builder.HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey(x => x.BrandId)
                .IsRequired();
        }
    }
}
