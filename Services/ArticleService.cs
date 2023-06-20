using facturacion.Models;
namespace facturacion.Services;

public class ArticleService : IArticleService
{
  FacturacionContext context;
  public ArticleService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Article article)
  {
    article.ArticleId = Guid.NewGuid();
    await context.AddAsync(article);
    await context.SaveChangesAsync();
    return article.ArticleId;
  }

  public IEnumerable<Article>? Read() => context.Articles;

  public async Task Update(Guid id, Article updated)
  {
    var article = context.Articles?.Find(id);
    if (article == null) return;
    article.Name = updated.Name;
    article.StockQuantity = updated.StockQuantity;
    article.CostPrice = updated.CostPrice;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var article = context.Articles?.Find(id);
    if (article == null) return;
    context.Remove(article);
    await context.SaveChangesAsync();
  }
}

public interface IArticleService
{
  Task<Guid> Create(Article article);
  IEnumerable<Article>? Read();
  Task Update(Guid id, Article upPlatform);
  Task Delete(Guid id);
}
