using facturacion.Models;
namespace facturacion.Services;

public class InventoryService : IInventoryService
{
  FacturacionContext context;
  public InventoryService(FacturacionContext dbContext) => context = dbContext;

  public async Task Create(Inventory inventory)
  {
    inventory.InventoryId = Guid.NewGuid();
    await context.AddAsync(inventory);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Inventory>? Read() => context.Inventories;

  /* Inventories shouldn't have an update method since the only property is articles */

  public async Task Delete(Guid id)
  {
    var inventory = context.Inventories?.Find(id);
    if (inventory == null) return;
    context.Remove(inventory);
    await context.SaveChangesAsync();
  }
}

public interface IInventoryService
{
  Task Create(Inventory inventory);
  IEnumerable<Inventory>? Read();
  Task Delete(Guid id);
}