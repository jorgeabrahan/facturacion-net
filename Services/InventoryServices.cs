using facturacion.Models;

public class InventoryService : IInventoryService
{
    //Inyeccion de dependencias.
    Context context;
    public InventoryService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    // public async Task Create(Inventory newPlatform)
    // {
    //     await context.AddAsync(newPlatform);
    //     await context.SaveChangesAsync();
    // }
    //Read
    public IEnumerable<Inventory> Read() => context.Inventorys;
    //update
    // public async Task Update(Guid id, Inventory UpdateInventory)
    // {
    //     var addNew = context.Inventorys.Find(id);
    //     if (addNew != null)
    //     {
    //         addNew.StockQuantity = UpdateInventory.StockQuantity;
    //         addNew.CostPrice = UpdateInventory.CostPrice;
    //         await context.SaveChangesAsync();
    //     }
    // }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Inventorys.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

    
}

public interface IInventoryService
{
  //  Task Create(Inventory newPlatform);
    IEnumerable<Inventory> Read();
   // Task Update(Guid id, Inventory upPlatform);
    Task Delete(Guid id);

}