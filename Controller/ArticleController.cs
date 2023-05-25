using Microsoft.AspNetCore.Mvc;
using facturacion.Models;

namespace facturacion.Controllers;

//atributos controller

[ApiController]
[Route ("api/[Controller]")]
public class ArticleController: ControllerBase{
    //inyeccion de dependencia

IArticleService articleService;
public ArticleController(IArticleService serviceArticle){
    articleService=serviceArticle;
}

 //Crud 
 //ATRIBUTOS DE ENDPOINTS
 //CREATE
 [HttpPost]
 public IActionResult Create([FromBody] Article newArticle){
articleService.Create(newArticle);
    return Ok("Datos guardados");
 }   

 [HttpGet]
 public IActionResult Read (){
    return Ok(articleService.Read());
 }
 [HttpPut("{id}")]
 public IActionResult Update([FromBody] Article ArticleUpdate, Guid id){
articleService.Update(id,ArticleUpdate);
    return Ok("Datos actualizados");

 }
[HttpDelete("{id}")]
public IActionResult Delete(Guid id){
articleService.Delete(id);
    return Ok();
}

}