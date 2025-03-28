using System;
using System.ComponentModel.DataAnnotations.Schema;
using HelloEfCore.Entities;

namespace HelloEfCore.Entities;

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

    public DateTime? DeletedDate { get; set; }
    
}
