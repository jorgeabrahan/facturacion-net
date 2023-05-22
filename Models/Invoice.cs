using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace facturacion.Models;
/* Factura */
public class Invoice
{
  /*
  An invoice belongs to a customer
  An invoice has many products
  */
  [Key]
  public Guid InvoiceId { get; set; }

  [ForeignKey("CustomerId")]
  public Guid CustomerId { get; set; }

  [Required]
  public float Total { get; set; }

  public DateTime CreationDate { get; set; }

  public virtual Customer? Customer { get; set; }
  public virtual ICollection<Product>? Products { get; set; }

  public Invoice()
  {
    Total = 0;
    /* Set creation date when an invoice is created */
    CreationDate = DateTime.Now;
  }
}
