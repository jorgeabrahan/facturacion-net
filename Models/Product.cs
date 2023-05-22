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

  [Required]
  public int Amount { get; set; }

  [Required]
  public float Price { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Article { get; set; }

  public virtual Invoice? Invoice { get; set; }

  public Product()
  {
    /* Set default amount of products */
    Amount = 1;
  }
}
