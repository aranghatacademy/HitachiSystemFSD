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
}

public enum LeaveStatus
{
    Pending,
    Approved,
    Rejected
}

public class LeaveRequest
{
    [Column("LeaveRequestId")]
    public int Id { get; set; }

    public Employee Employee { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Reason { get; set; }

    public LeaveStatus Status { get; set; }
    
}
