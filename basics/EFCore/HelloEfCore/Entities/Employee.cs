using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloEfCore.Entities;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(360)]
    public string Email { get; set; }

    [Required]
    [MaxLength(10)]
    public string Phone { get; set; }
    
    public string? Note { get; set; }

    public decimal? Salary { get; set; }

    [Timestamp]
    public byte [] RowVersion { get; set; }

    public DateTime? LastModified { get; set; }

    public DateTime? DeletedDate { get; set; }
}




