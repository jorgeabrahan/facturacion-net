using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class InventoryController : ControllerBase
{
  IInventoryService service;
  public InventoryController(IInventoryService inventoryService) => service = inventoryService;

  [HttpPost]
  public async Task<IActionResult> CreateInventory([FromBody] Inventory inventory) => Ok(await service.Create(inventory));

  [HttpGet]
  public IActionResult ReadInventories() => Ok(service.Read());

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteInventory(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}