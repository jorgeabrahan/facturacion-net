using facturacion.Models;

public class CustomerService : ICustomerService
{
    //Inyeccion de dependencias.
    Context context;
    public CustomerService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(Customer newCustomer)
    {
        await context.AddAsync(newCustomer);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<Customer> Read() => context.Customers;
    //update
    public async Task Update(Guid id, Customer UpCustomer)
    {
        var test = context.Customers.Find(id);
        if (test == null) return;

        test.Name = UpCustomer.Name;
        test.Address = UpCustomer.Address;
        test.RTN = UpCustomer.RTN;
        test.PhoneNumber = UpCustomer.PhoneNumber;
        test.CustomerType = UpCustomer.CustomerType;
        await context.SaveChangesAsync();

    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Customers.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICustomerService
{
    Task Create(Customer newCustomer);
    IEnumerable<Customer> Read();
    Task Update(Guid id, Customer upCustomer);
    Task Delete(Guid id);

}