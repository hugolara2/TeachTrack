using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Teacher
{
    public int Teacherid { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public short Active { get; set; }

    public virtual ICollection<InfoTeacher> InfoTeachers { get; set; } = new List<InfoTeacher>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
