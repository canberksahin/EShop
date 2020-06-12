using ApplicationCore.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //bu classın o an çalıstıgı yeri ara, bunların configuration dosyasını bul.. miras aldıgı yerlere bakabilir.
            //her entity için ayrı configuration olusuturulacak
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            // https://www.learnentityframeworkcore.com/configuration/fluent-api
            //tek tek category eklendiği gibi eklenedebilirdi.
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //category'i required ve maxlength verilebilir.
            //modelBuilder.Entity<Category>()
            //.Property(x => x.CategoryName)
            // .IsRequired()
            //.HasMaxLength(100);
        }
    }
}
