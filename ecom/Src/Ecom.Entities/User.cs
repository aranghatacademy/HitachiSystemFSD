using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Entities;

public class User : BaseObject
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    
    
}
