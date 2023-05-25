using facturacion.Models;

public class UserService : IUserService
{
    //Inyeccion de dependencias.
    Context context;
    public UserService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(User newinvoice)
    {
        await context.AddAsync(newinvoice);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<User> Read() => context.Users;
    //update
    public async Task Update(Guid id, User UpdateUser)
    {
        var addNew = context.Users.Find(id);
        if (addNew == null) return;
        
            addNew.Username = UpdateUser.Username;
            addNew.Password = UpdateUser.Password;
         
            await context.SaveChangesAsync();
        
    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Users.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface IUserService
{
    Task Create(User newinvoice);
    IEnumerable<User> Read();
    Task Update(Guid id, User upinvoice);
    Task Delete(Guid id);

}