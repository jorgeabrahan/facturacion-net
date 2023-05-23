using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace facturacion.Models;
/* Articulo */
public class Article
{
  [Key]
  public Guid ArticleId { get; set; }

  [ForeignKey("InventoryId")]
  public Guid InventoryId { get; set; }

  [Required]
  public int StockQuantity { get; set; }

  [Required]
  public float CostPrice { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Name { get; set; }

  public virtual Inventory? Inventory { get; set; }
}
