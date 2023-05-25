using facturacion.Models;

public class InvoiceService : IInvoiceService
{
    //Inyeccion de dependencias.
    Context context;
    public InvoiceService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(Invoice newinvoice)
    {
        await context.AddAsync(newinvoice);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<Invoice> Read() => context.Invoices;
    //update
    public async Task Update(Guid id, Invoice Upinvoice)
    {
        var test = context.Invoices.Find(id);
        if (test == null) return;
        
            test.SubTotal = Upinvoice.SubTotal;
            test.ISV = Upinvoice.ISV;
            test.Total = Upinvoice.Total;
            test.CreationDate = Upinvoice.CreationDate;
            await context.SaveChangesAsync();
        
    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Invoices.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface IInvoiceService
{
    Task Create(Invoice newinvoice);
    IEnumerable<Invoice> Read();
    Task Update(Guid id, Invoice upinvoice);
    Task Delete(Guid id);

}