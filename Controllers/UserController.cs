using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
  IUserService service;
  public UserController(IUserService userService) => service = userService;

  [HttpPost]
  public async Task<IActionResult> CreateUser([FromBody] User user) => Ok(await service.Create(user));

  [HttpGet]
  public IActionResult ReadUsers() => Ok(service.Read());

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateUser([FromBody] User user, Guid id)
  {
    await service.Update(id, user);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}
