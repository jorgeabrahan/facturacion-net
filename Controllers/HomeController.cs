using Microsoft.AspNetCore.Mvc;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
  FacturacionContext dbcontext;
  public HomeController(FacturacionContext db) => dbcontext = db;

  [HttpGet]
  [Route("connect")]
  public IActionResult connect()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}