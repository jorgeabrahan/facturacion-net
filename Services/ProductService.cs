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
    public async Task Update(Guid id, Product UpdateProducts)
    {
        var addNew = context.Products.Find(id);
        if (addNew == null) return;
        
            addNew.Amount = UpdateProducts.Amount;
            addNew.Price = UpdateProducts.Price;
            addNew.Total = UpdateProducts.Total;
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