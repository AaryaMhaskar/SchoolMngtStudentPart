using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
