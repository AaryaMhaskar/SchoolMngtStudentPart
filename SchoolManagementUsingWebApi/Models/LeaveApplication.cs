using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class LeaveApplication
{
    public int LeaveApplicationId { get; set; }

    public int TeacherId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string Reason { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
