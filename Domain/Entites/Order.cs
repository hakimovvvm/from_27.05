using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Order
{
    [Key]
    [Column("OrderId")]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Customer")]
    [Column("CustomerId")]
    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }
    
    [Range(0, 999999)]
    public decimal TotalAmount { get; set; }

    public Customer Customer { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }     

}
