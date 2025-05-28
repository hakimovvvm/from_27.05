using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        modelBuilder.Entity<Product>()
        .Property(p => p.Description)
        .IsRequired(false)
        .HasMaxLength(150);

        modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .IsRequired();

        modelBuilder.Entity<OrderDetail>()
        .HasKey(od => od.Id);

        modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderDetails)
        .WithOne(od => od.Order)
        .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<Product>()
        .HasMany(p => p.OrderDetails)
        .WithOne(od => od.Product)
        .HasForeignKey(od => od.ProductId);

    }

}
    