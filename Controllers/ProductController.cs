using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
  IProductService service;
  public ProductController(IProductService productService) => service = productService;

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] Product product) => Ok(await service.Create(product));

  [HttpGet]
  public IActionResult ReadProducts() => Ok(service.Read());

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateProduct([FromBody] Product product, Guid id)
  {
    await service.Update(id, product);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}
