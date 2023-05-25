using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class InventoryController: ControllerBase{
    //inyeccion de dependencia

IInventoryService inventoryService;
public InventoryController(IInventoryService serviceInventory){
    inventoryService=serviceInventory;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 /*
 [HttpPost]
 public IActionResult Create([FromBody] Inventory newInventory){
articleService.Create(newArticle);
    return Ok("Datos guardados");
 }   
*/
 [HttpGet]
 public IActionResult Read (){
    return Ok(inventoryService.Read());
 }
 /*
 [HttpPut("{id}")]
 public IActionResult Update([FromBody] Article ArticleUpdate, Guid id){
articleService.Update(id,ArticleUpdate);
    return Ok("Datos actualizados");

 }*/
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
inventoryService.Delete(id);
    return Ok();
}

}