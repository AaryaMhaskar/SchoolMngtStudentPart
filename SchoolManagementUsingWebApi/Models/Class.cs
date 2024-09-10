using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public decimal AnnualFees { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
