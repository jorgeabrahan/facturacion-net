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

  public float SubTotal { get; set; }
  public float ISV { get; set; }
  public float Total { get; set; }

  public DateTime CreationDate { get; set; }

  public virtual Customer? Customer { get; set; }
  public virtual ICollection<Product>? Products { get; set; }

  public Invoice()
  {
    SubTotal = 0;
    ISV = 0;
    Total = 0;
    /* Set creation date when an invoice is created */
    CreationDate = DateTime.Now;
  }
}
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

  public float SubTotal { get; set; }
  public float ISV { get; set; }
  public float Total { get; set; }

  public DateTime CreationDate { get; set; }

  public virtual Customer? Customer { get; set; }
  public virtual ICollection<Product>? Products { get; set; }

  public Invoice()
  {
    SubTotal = 0;
    ISV = 0;
    Total = 0;
    /* Set creation date when an invoice is created */
    CreationDate = DateTime.Now;
  }
}
