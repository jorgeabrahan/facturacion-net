using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace facturacion.Models;
/* Informe */
public class Report
{
  /*
  A report has many invoices
  */
  [Key]
  public Guid ReportId { get; set; }

  [ForeignKey("InvoiceId")]
  public Guid InvoiceId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Title { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Content { get; set; }

  [Required]
  public float TotalBills { get; set; }

  public virtual ICollection<Invoice>? Invoices { get; set; }

  public IEnumerable<Invoice> FilterInvoices(DateTime startDate, DateTime endDate)
  {
    if (Invoices == null)
    {
      return Enumerable.Empty<Invoice>();
    }
    return Invoices.Where(invoice => invoice.CreationDate >= startDate && invoice.CreationDate <= endDate);
  }
}
