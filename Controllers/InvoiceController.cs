using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class InvoiceController : ControllerBase
{
  IInvoiceService service;
  public InvoiceController(IInvoiceService invoiceService) => service = invoiceService;

  [HttpPost]
  public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice) => Ok(await service.Create(invoice));

  [HttpGet]
  public IActionResult ReadInvoices() => Ok(service.Read());

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice, Guid id)
  {
    await service.Update(id, invoice);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteInvoice(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}