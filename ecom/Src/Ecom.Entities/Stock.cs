using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Entities;

public class Stock : BaseObject
{
    [Required]
    public Product Product { get; set; }

    [Required]
    public int TotalStock { get; set; }
}
