using Microsoft.AspNetCore.Mvc;

namespace facturacion.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  FacturacionContext dbcontext;
  public HomeController(FacturacionContext db) => dbcontext = db;

  [HttpGet]
  [Route("conectar")]
  public IActionResult conectar()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}