using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Customer
{
    [Key]
    [Column("CustomerId")]
    public int Id { get; set; }
    
    [MaxLength(50)]
    [MinLength(3)]
    [Required(ErrorMessage = "Имя обязаельно нужно заполнить!")]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    public DateTime RegisteredOn { get; set; }

    public List<Order> Orders { get; set; }
}
