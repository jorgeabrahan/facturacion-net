using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class CustomerController: ControllerBase{
    //inyeccion de dependencia

ICustomerService customerService;
public CustomerController(ICustomerService serviceCustomer){
    customerService=serviceCustomer;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] Customer newCustomer){
customerService.Create(newCustomer);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(customerService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody] Customer customerUpdate, Guid id){
customerService.Update(id,customerUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
customerService.Delete(id);
    return Ok();
}

}