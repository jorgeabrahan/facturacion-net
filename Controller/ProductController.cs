using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class ProductController: ControllerBase{
    //inyeccion de dependencia

IProductService productService;
public ProductController(IProductService serviceProduct){
    productService=serviceProduct;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] Product newProduct){
productService.Create(newProduct);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(productService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody]Product productUpdate, Guid id){
productService.Update(id,productUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
productService.Delete(id);
    return Ok();
}

}
