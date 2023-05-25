using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class ReportController: ControllerBase{
    //inyeccion de dependencia

IReportService reportService;
public ReportController(IReportService serviceReport){
    reportService=serviceReport;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] Report newReport){
reportService.Create(newReport);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(reportService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody]Report reportUpdate, Guid id){
reportService.Update(id,reportUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
reportService.Delete(id);
    return Ok();
}

}
