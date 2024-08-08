using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Schedule
{
    public int Scheduleid { get; set; }

    public int Subject { get; set; }

    public string Dayofweek1 { get; set; } = null!;

    public TimeOnly Starttime1 { get; set; }

    public TimeOnly Endtime1 { get; set; }

    public string? Dayofweek2 { get; set; }

    public TimeOnly? Starttime2 { get; set; }

    public TimeOnly? Endtime2 { get; set; }

    public string? Dayofweek3 { get; set; }

    public TimeOnly? Starttime3 { get; set; }

    public TimeOnly? Endtime3 { get; set; }

    public string? Room { get; set; }

    public virtual Subject SubjectNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
