using facturacion.Models;

public class ReportService : IReportService
{
    //Inyeccion de dependencias.
    Context context;
    public ReportService(Context DbContext) => context = DbContext;

    //CRUD
    //create
    public async Task Create(Report newinvoice)
    {
        await context.AddAsync(newinvoice);
        await context.SaveChangesAsync();
    }
    //Read
    public IEnumerable<Report> Read() => context.Reports;
    //update
    public async Task Update(Guid id, Report UpdateReport)
    {
        var addNew = context.Reports.Find(id);
        if (addNew == null) return;
        
            addNew.Title = UpdateReport.Title;
            addNew.Content = UpdateReport.Content;
            addNew.TotalBills = UpdateReport.TotalBills;
           
            await context.SaveChangesAsync();
        
    }

    //Delelte

    public async Task Delete(Guid id)
    {
        var test = context.Reports.Find(id);
        if (test != null)
        {
            context.Remove(test);
            await context.SaveChangesAsync();
        }
    }

}

public interface IReportService
{
    Task Create(Report newinvoice);
    IEnumerable<Report> Read();
    Task Update(Guid id, Report upinvoice);
    Task Delete(Guid id);

}