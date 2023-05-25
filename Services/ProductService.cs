using facturacion.Models;

public class ProductService : IProductService
{
    //Inyeccion de dependencias.
    Context context;
    public ProductService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(Product newproduct)
    {
        await context.AddAsync(newproduct);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<Product> Read() => context.Products;
    //update
    public async Task Update(Guid id, Product Upproduct)
    {
        var test = context.Products.Find(id);
        if (test == null) return;
        
            test.Amount = Upproduct.Amount;
            test.Price = Upproduct.Price;
            test.Total = Upproduct.Total;
            await context.SaveChangesAsync();
        
    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Products.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface IProductService
{
    Task Create(Product newproduct);
    IEnumerable<Product> Read();
    Task Update(Guid id, Product upproduct);
    Task Delete(Guid id);

}