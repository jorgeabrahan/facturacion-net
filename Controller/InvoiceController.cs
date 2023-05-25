using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class InvoiceController: ControllerBase{
    //inyeccion de dependencia

IInvoiceService invoiceService;
public InvoiceController(IInvoiceService serviceInvoice){
    invoiceService=serviceInvoice;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] Invoice newInvoice){
invoiceService.Create(newInvoice);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(invoiceService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody] Invoice invoiceUpdate, Guid id){
invoiceService.Update(id,invoiceUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
invoiceService.Delete(id);
    return Ok();
}

}