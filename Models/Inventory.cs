using System.ComponentModel.DataAnnotations;

namespace facturacion.Models;
/* Inventario */
public class Inventory
{
  [Key]
  public Guid InventoryId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Name { get; set; }

  public virtual ICollection<Article>? Article { get; set; }
}
