using System.ComponentModel.DataAnnotations;

namespace facturacion.Models;
/* Cliente */
public class Customer
{
  [Key]
  public Guid CustomerId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Name { get; set; }

  [MaxLength(250)]
  public String? Address { get; set; }

  [Required]
  [MaxLength(250)]
  public String? RTN { get; set; }

  [Required]
  [MaxLength(250)]
  public String? PhoneNumber { get; set; }

  public CustomerTypes CustomerType { get; set; }

  public Customer()
  {
    CustomerType = CustomerTypes.Normal;
  }
}

public enum CustomerTypes
{
  Normal,
  Wholesale,
  Internal
}
