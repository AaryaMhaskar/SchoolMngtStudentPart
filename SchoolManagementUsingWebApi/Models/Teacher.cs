using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal MonthlySalary { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<LeaveApplication> LeaveApplications { get; } = new List<LeaveApplication>();

    public virtual Subject Subject { get; set; } = null!;
}
