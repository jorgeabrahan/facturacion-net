using facturacion.Models;
namespace facturacion.Services;

public class CustomerService : ICustomerService
{
  FacturacionContext context;
  public CustomerService(FacturacionContext dbContext) => context = dbContext;

  public async Task Create(Customer customer)
  {
    customer.CustomerId = Guid.NewGuid();
    await context.AddAsync(customer);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Customer>? Read() => context.Customers;

  public async Task Update(Guid id, Customer updated)
  {
    var customer = context.Customers?.Find(id);
    if (customer == null) return;
    customer.Name = updated.Name;
    customer.Address = updated.Address;
    customer.RTN = updated.RTN;
    customer.PhoneNumber = updated.PhoneNumber;
    customer.CustomerType = updated.CustomerType;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var customer = context.Customers?.Find(id);
    if (customer == null) return;
    context.Remove(customer);
    await context.SaveChangesAsync();
  }
}

public interface ICustomerService
{
  Task Create(Customer customer);
  IEnumerable<Customer>? Read();
  Task Update(Guid id, Customer updated);
  Task Delete(Guid id);
}