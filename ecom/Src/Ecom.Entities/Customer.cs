using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Entities;

public class Customer : User
{
    [Required]
    [MaxLength(10)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }

    public string ApiSecret { get; set; }

    public string ApiKey { get; set; }

}
