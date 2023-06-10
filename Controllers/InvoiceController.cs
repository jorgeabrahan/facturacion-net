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
  public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
  {
    var (invoiceId, creationDate) = await service.Create(invoice);
    return Ok(new { InvoiceId = invoiceId, CreationDate = creationDate });
  }

  [HttpGet]
  public IActionResult ReadInvoices() => Ok(service.Read());

  [HttpGet("{id}/products")]
  public IActionResult ReadProducts(Guid id) => Ok(service.ReadProducts(id));

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