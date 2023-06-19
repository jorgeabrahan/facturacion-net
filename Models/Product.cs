using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace facturacion.Models;
/* Producto */
public class Product
{
  /*
  A product belongs to an invoice
  */
  [Key]
  public Guid ProductId { get; set; }

  [ForeignKey("InvoiceId")]
  public Guid InvoiceId { get; set; }

  [ForeignKey("ArticleId")]
  public Guid ArticleId { get; set; }

  [Required]
  public int Amount { get; set; }

  public float Price { get; set; }

  public float Total { get; set; }

  public virtual Article? Article { get; set; }
  public virtual Invoice? Invoice { get; set; }
}
