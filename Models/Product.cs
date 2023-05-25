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

  public Product()
  {
    if (Article == null || ((Article.StockQuantity - Amount) < 0)) return;
    Article.StockQuantity -= Amount; // subtract the amount purchased by the customer
    this.CalculatePrice();
    this.CalculateTotal();
    this.CalculateInvoiceTotal();
  }

  public void CalculatePrice()
  {
    if (Invoice == null || Invoice.Customer == null || Article == null) return;
    float profits = 0;
    switch (Invoice.Customer.CustomerType)
    {
      case CustomerTypes.Wholesale: profits = 0.07f; break;
      case CustomerTypes.Internal: profits = 0.05f; break;
      default: profits = 0.12f; break; // if normal
    }
    this.Price = Article.CostPrice + (Article.CostPrice * profits);
  }

  public void CalculateTotal()
  {
    this.Total = this.Price * this.Amount;
  }

  public void CalculateInvoiceTotal()
  {
    /* Update invoice total when a new product is created */
    if (this.Invoice == null) return;
    this.Invoice.SubTotal += this.Total;
    this.Invoice.ISV = this.Invoice.SubTotal * 0.15f;
    this.Invoice.Total = this.Invoice.ISV + this.Invoice.SubTotal;
  }
}
