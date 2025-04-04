using System;

namespace Ecom.Entities;

public abstract class BaseObject
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    
    
}
