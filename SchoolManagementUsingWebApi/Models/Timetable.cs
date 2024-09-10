using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Timetable
{
    public int TimetableId { get; set; }

    public int ClassId { get; set; }

    public string FilePath { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}
