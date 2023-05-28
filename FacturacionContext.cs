
using Microsoft.EntityFrameworkCore;
using facturacion.Models;

namespace facturacion;

public class FacturacionContext : DbContext
{
  public DbSet<Article>? Articles { get; set; }
  public DbSet<Customer>? Customers { get; set; }
  public DbSet<Inventory>? Inventories { get; set; }
  public DbSet<Invoice>? Invoices { get; set; }
  public DbSet<Product>? Products { get; set; }
  public DbSet<Report>? Reports { get; set; }
  public DbSet<User>? Users { get; set; }

  public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options) { }
}