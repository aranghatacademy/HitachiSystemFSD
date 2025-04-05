using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Services.Users;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
