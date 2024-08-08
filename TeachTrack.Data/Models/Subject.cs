using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Subject
{
    public int Subjectid { get; set; }

    public string Name { get; set; } = null!;

    public string Subjectcode { get; set; } = null!;

    public int Program { get; set; }

    public string Description { get; set; } = null!;

    public virtual Program ProgramNavigation { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
