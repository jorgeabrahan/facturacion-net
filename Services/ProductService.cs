using facturacion.Models;
namespace facturacion.Services;

public class ProductService : IProductService
{
  FacturacionContext context;
  public ProductService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Product product)
  {
    product.ProductId = Guid.NewGuid();
    await context.AddAsync(product);
    await context.SaveChangesAsync();
    return product.ProductId;
  }

  public IEnumerable<Product>? Read() => context.Products;

  public async Task Update(Guid id, Product updated)
  {
    var product = context.Products?.Find(id);
    if (product == null) return;
    product.Amount = updated.Amount;
    product.Price = updated.Price;
    product.Total = updated.Total;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var product = context.Products?.Find(id);
    if (product == null) return;
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
