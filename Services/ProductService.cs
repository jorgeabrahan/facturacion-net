using facturacion.Models;
using Microsoft.EntityFrameworkCore;

namespace facturacion.Services;

public class ProductService : IProductService
{
  FacturacionContext context;
  public ProductService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Product product)
  {
    product.ProductId = Guid.NewGuid();
    // Get the related Article from the database
    var article = await context.Articles?.FirstOrDefaultAsync(a => a.ArticleId == product.ArticleId);
    // Subtract the Amount of the Product from the StockQuantity of the Article
    if (article != null)
    {
      article.StockQuantity -= product.Amount;
    }
    await context.AddAsync(product);
    await context.SaveChangesAsync();
    return product.ProductId;
  }

  public IEnumerable<Product>? Read() => context?.Products?.Include(p => p.Article);

  public async Task Update(Guid id, Product updated)
  {
    var product = await context.Products.FindAsync(id);
    if (product == null) return;

    // Get the related Article from the database
    var article = await context.Articles.FirstOrDefaultAsync(a => a.ArticleId == product.ArticleId);

    // Add the original Amount of the Product back to the StockQuantity of the Article
    if (article != null)
    {
      article.StockQuantity += product.Amount;
    }

    // Update the Product properties
    product.Amount = updated.Amount;
    product.Price = updated.Price;
    product.Total = updated.Total;

    // Subtract the new Amount of the Product from the StockQuantity of the Article
    if (article != null)
    {
      article.StockQuantity -= product.Amount;
    }

    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var product = await context.Products.FindAsync(id);
    if (product == null) return;

    // Get the related Article from the database
    var article = await context.Articles.FirstOrDefaultAsync(a => a.ArticleId == product.ArticleId);

    // Add the Amount of the Product back to the StockQuantity of the Article
    if (article != null)
    {
      article.StockQuantity += product.Amount;
    }

    context.Remove(product);
    await context.SaveChangesAsync();
  }
}

public interface IProductService
{
  Task<Guid> Create(Product product);
  IEnumerable<Product>? Read();
  Task Update(Guid id, Product updated);
  Task Delete(Guid id);
}
