using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class UserController: ControllerBase{
    //inyeccion de dependencia

IUserService userService;
public UserController(IUserService serviceUser){
    userService=serviceUser;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] User newUser){
userService.Create(newUser);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(userService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody] User userUpdate, Guid id){
userService.Update(id, userUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
userService.Delete(id);
    return Ok();
}

}
