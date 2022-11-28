using Microsoft.EntityFrameworkCore;
using product.Models;

namespace product.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Booth> Booth { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Rate> Rate { get; set; }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure default schema
        modelBuilder.HasDefaultSchema("product");

        modelBuilder.Entity<Booth>(productEntityBuilder =>
        {
            productEntityBuilder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .IsRequired();

            productEntityBuilder.Property(p => p.Title)
                .HasColumnName("Title")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("text")
                .IsRequired();
        });

        modelBuilder.Entity<Product>(productEntityBuilder =>
            {
                productEntityBuilder.Property(p => p.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .IsRequired();

                productEntityBuilder.Property(p => p.Title)
                    .HasColumnName("Title")
                    .HasColumnType("text")
                    .IsRequired();

                productEntityBuilder.Property(p => p.Description)
                    .HasColumnName("Description")
                    .HasColumnType("text")
                    .IsRequired();
            }
        );
        
        modelBuilder.Entity<Stock>(productEntityBuilder =>
        {
            productEntityBuilder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .IsRequired();

            productEntityBuilder.Property(p => p.Size)
                .HasColumnName("Size")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.Gender)
                .HasColumnName("Gender")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.Department)
                .HasColumnName("Department")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.Category)
                .HasColumnName("Category")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            productEntityBuilder.Property(p => p.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("integer")
                .IsRequired();
        });
        
        modelBuilder.Entity<Rate>(productEntityBuilder =>
        {
            productEntityBuilder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .IsRequired();
            
            productEntityBuilder.Property(p => p.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .IsRequired();

            productEntityBuilder.Property(p => p.Grade)
                .HasColumnName("Grade")
                .HasColumnType("integer")
                .IsRequired();

            productEntityBuilder.Property(p => p.CommentTitle)
                .HasColumnName("CommentTitle")
                .HasColumnType("text")
                .IsRequired();

            productEntityBuilder.Property(p => p.CommentBody)
                .HasColumnName("CommentBody")
                .HasColumnType("text")
                .IsRequired();
        });
        
        modelBuilder.Entity<Booth>()
            .HasMany(b => b.Products)
            .WithOne(p => p.Booth)
            .IsRequired();
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Stocks)
            .WithOne(s => s.Product)
            .IsRequired();
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Rates)
            .WithOne(r => r.Product)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}