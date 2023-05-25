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
    public async Task Update(Guid id, Invoice UpdateInvoice)
    {
        var addNew = context.Invoices.Find(id);
        if (addNew == null) return;
        
            addNew.SubTotal = UpdateInvoice.SubTotal;
            addNew.ISV = UpdateInvoice.ISV;
            addNew.Total = UpdateInvoice.Total;
            addNew.CreationDate = UpdateInvoice.CreationDate;
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