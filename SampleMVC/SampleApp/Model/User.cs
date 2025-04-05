using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public string RegistrationNumber { get; set; }

    public string Password { get; set; }
    public bool IsTeacher { get; set; }

    [Column(TypeName = "jsonb")]
    public List<string> Departments { get; set; }

    public string State { get; set; }
}
