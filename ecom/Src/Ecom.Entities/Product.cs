using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Entities;

public class Product : BaseObject
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public bool IsAvailable { get; set; }
}
