using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace facturacion.Models;
/* Estadistica */
public class Statistics
{
  /*
  Statistics belong to a report
  */
  [Key]
  public Guid StatisticsId { get; set; }

  [ForeignKey("ReportId")]
  public Guid ReportId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Name { get; set; }

  [Required]
  public float TotalBills { get; set; }

  public virtual Report? Report { get; set; }
}
