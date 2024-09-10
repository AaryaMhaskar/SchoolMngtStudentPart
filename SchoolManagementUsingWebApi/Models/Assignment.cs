using System;
using System.Collections.Generic;

namespace SchoolManagementUsingWebApi.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime AssignDate { get; set; }

    public DateTime SubmissionDate { get; set; }

    public string FilePath { get; set; } = null!;

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public virtual ICollection<AssignmentResponse> AssignmentResponses { get; } = new List<AssignmentResponse>();

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
