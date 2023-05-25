using Microsoft.AspNetCore.Mvc;
using facturacion.Models;
using facturacion.Services;

namespace facturacion.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ArticleController : ControllerBase
{
  IArticleService service;
  public ArticleController(IArticleService articleService) => service = articleService;

  [HttpPost]
  public async Task<IActionResult> CreateArticle([FromBody] Article article) => Ok(await service.Create(article));

  [HttpGet]
  public IActionResult ReadArticles() => Ok(service.Read());

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateArticle([FromBody] Article article, Guid id)
  {
    await service.Update(id, article);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteArticle(Guid id)
  {
    await service.Delete(id);
    return Ok();
  }
}