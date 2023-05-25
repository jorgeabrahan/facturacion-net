
using facturacion.Models;
using Microsoft.EntityFrameworkCore;


public class Context:DbContext {
public DbSet<Article> Articles{get;set;}

public DbSet<Customer> Customers{get;set;}
public DbSet<Inventory> Inventorys{get;set;}
public DbSet<Invoice> Invoices{get;set;}
public DbSet<Product> Products{get;set;}
public DbSet<Report> Reports{get;set;}
public DbSet<User> Users{get;set;}


public Context(DbContextOptions<Context> options) : base(options){}

}