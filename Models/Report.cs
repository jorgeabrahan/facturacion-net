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

  public virtual ICollection<Invoice>? Invoices { get; set; }
}
