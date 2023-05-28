using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CustomerController : ControllerBase
{
  ICustomerService service;
  public CustomerController(ICustomerService customerService) => service = customerService;

  [HttpPost]
  public async Task<IActionResult> CreateCustomer([FromBody] Customer customer) => Ok(await service.Create(customer));

  [HttpGet]
  public IActionResult ReadCustomers() => Ok(service.Read());

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer, Guid id)
  {
    await service.Update(id, customer);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCustomer(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}
