using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Services.Users;

public class RegistrationRequest
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

    public dynamic AdditionalInfo { get; set; }
}
