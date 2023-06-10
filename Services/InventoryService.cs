using facturacion.Models;
namespace facturacion.Services;

public class InventoryService : IInventoryService
{
  FacturacionContext context;
  public InventoryService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Inventory inventory)
  {
    inventory.InventoryId = Guid.NewGuid();
    await context.AddAsync(inventory);
    await context.SaveChangesAsync();
    return inventory.InventoryId;
  }

  public IEnumerable<Inventory>? Read() => context.Inventories;

  public async Task Update(Guid id, Inventory updated)
  {
    var inventory = context.Inventories?.Find(id);
    if (inventory == null) return;
    inventory.Name = updated.Name;
    await context.SaveChangesAsync();
  }

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
  Task<Guid> Create(Inventory inventory);
  IEnumerable<Inventory>? Read();
  Task Delete(Guid id);
}