using facturacion.Models;
namespace facturacion.Services;

public class InvoiceService : IInvoiceService
{
  FacturacionContext context;
  public InvoiceService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Invoice invoice)
  {
    invoice.InvoiceId = Guid.NewGuid();
    await context.AddAsync(invoice);
    await context.SaveChangesAsync();
    return invoice.InvoiceId;
  }

  public IEnumerable<Invoice>? Read() => context.Invoices;

  public async Task Update(Guid id, Invoice updated)
  {
    var invoice = context.Invoices?.Find(id);
    if (invoice == null) return;
    invoice.SubTotal = updated.SubTotal;
    invoice.ISV = updated.ISV;
    invoice.Total = updated.Total;
    /* The creation date can't be updated */
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var invoice = context.Invoices?.Find(id);
    if (invoice == null) return;
    context.Remove(invoice);
    await context.SaveChangesAsync();
  }
}

public interface IInvoiceService
{
  Task<Guid> Create(Invoice invoice);
  IEnumerable<Invoice>? Read();
  Task Update(Guid id, Invoice updated);
  Task Delete(Guid id);
}
