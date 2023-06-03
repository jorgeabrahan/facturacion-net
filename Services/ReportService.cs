using facturacion.Models;
namespace facturacion.Services;

public class ReportService : IReportService
{
  FacturacionContext context;
  public ReportService(FacturacionContext dbContext) => context = dbContext;

  public async Task<Guid> Create(Report report)
  {
    report.ReportId = Guid.NewGuid();
    await context.AddAsync<Report>(report);
    await context.SaveChangesAsync();
    return report.ReportId;
  }

  public IEnumerable<Report>? Read() => context.Reports;

  public async Task Update(Guid id, Report updated)
  {
    var report = context.Reports?.Find(id);
    if (report == null) return;
    report.Title = updated.Title;
    report.Content = updated.Content;
    report.TotalBills = updated.TotalBills;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var report = context.Reports?.Find(id);
    if (report == null) return;
    context.Remove(report);
    await context.SaveChangesAsync();
  }
}

public interface IReportService
{
  Task<Guid> Create(Report report);
  IEnumerable<Report>? Read();
  Task Update(Guid id, Report updated);
  Task Delete(Guid id);
}