using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Entities;

public class Order : BaseObject
{
    [Required]
    public Customer Customer { get; set; }

    [Required]
    public Product Product { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public OrderStatus Status { get; set; }
    
    
}
