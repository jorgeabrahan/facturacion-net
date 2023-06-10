using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ReportController : ControllerBase
{
  //inyeccion de dependencia

  IReportService service;
  public ReportController(IReportService reportService) => service = reportService;

  [HttpPost]
  public async Task<IActionResult> CreateReport([FromBody] Report report) => Ok(await service.Create(report));

  [HttpGet]
  public IActionResult ReadReports() => Ok(service.Read());

  [HttpGet("{id}/invoices")]
  public IActionResult ReadInvoices(Guid id) => Ok(service.ReadInvoices(id));

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateReport([FromBody] Report report, Guid id)
  {
    await service.Update(id, report);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteReport(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}
