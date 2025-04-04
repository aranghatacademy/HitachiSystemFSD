using System.ComponentModel.DataAnnotations;

namespace Ecom.Entities;

public class Customer : User
{
    [Required]
    [MaxLength(10)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }

}
