using System.ComponentModel.DataAnnotations;

namespace facturacion.Models;
/* Informe */
public class Report
{
  /*
  A report has many invoices
  */
  [Key]
  public Guid ReportId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Title { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Content { get; set; }

  public float TotalBills { get; set; }

  public virtual ICollection<Invoice>? Invoices { get; set; }

  public Report() {
    this.TotalBills = 0;
  }

  public IEnumerable<Invoice> FilterInvoices(DateTime startDate, DateTime endDate)
  {
    if (Invoices == null)
    {
      return Enumerable.Empty<Invoice>();
    }
    return Invoices.Where(invoice => invoice.CreationDate >= startDate && invoice.CreationDate <= endDate);
  }
}
