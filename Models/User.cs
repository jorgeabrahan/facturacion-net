using System.ComponentModel.DataAnnotations;

namespace facturacion.Models;
/* Usuario */
public class User
{
  [Key]
  public Guid UserId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Username { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Password { get; set; }
}
