using facturacion.Models;

public class ArticleService : IArticleService
{
    //Inyeccion de dependencias.
    Context context;
    public ArticleService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(Article newPlatform)
    {
        await context.AddAsync(newPlatform);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<Article> Read() => context.Articles;
    //update
    public async Task Update(Guid id, Article UpdateArticle)
    {
        var addNew = context.Articles.Find(id);
        if (addNew != null)
        {
            addNew.StockQuantity = UpdateArticle.StockQuantity;
            addNew.CostPrice = UpdateArticle.CostPrice;
            await context.SaveChangesAsync();
        }
    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Articles.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface IArticleService
{
    Task Create(Article newPlatform);
    IEnumerable<Article> Read();
    Task Update(Guid id, Article upPlatform);
    Task Delete(Guid id);

}