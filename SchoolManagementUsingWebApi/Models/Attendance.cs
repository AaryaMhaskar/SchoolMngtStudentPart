using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int StudentId { get; set; }

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }

    public virtual Student Student { get; set; } = null!;
}
