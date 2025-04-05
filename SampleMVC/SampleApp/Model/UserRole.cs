using System;

namespace SampleApp.Model;

public class UserRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<RoleMenu> Menus { get; set; }
}


public class RoleMenu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    public int? ParentId { get; set; }
    
}