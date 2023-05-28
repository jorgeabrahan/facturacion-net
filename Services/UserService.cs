using facturacion.Models;
namespace facturacion.Services;

public class UserService : IUserService
{
  FacturacionContext context;
  public UserService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(User user)
  {
    user.UserId = Guid.NewGuid();
    await context.AddAsync<User>(user);
    await context.SaveChangesAsync();
    return user.UserId;
  }

  public IEnumerable<User>? Read() => context.Users;

  public async Task Update(Guid id, User updated)
  {
    var user = context.Users?.Find(id);
    if (user == null) return;
    user.Username = updated.Username;
    user.Password = updated.Password;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var user = context.Users?.Find(id);
    if (user == null) return;
    context.Remove(user);
    await context.SaveChangesAsync();
  }
}

public interface IUserService
{
  Task<Guid> Create(User user);
  IEnumerable<User>? Read();
  Task Update(Guid id, User updated);
  Task Delete(Guid id);
}