using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public short Degree { get; set; }

    public int Program { get; set; }

    public short Active { get; set; }

    public virtual Degree DegreeNavigation { get; set; } = null!;

    public virtual ICollection<InfoStudent> InfoStudents { get; set; } = new List<InfoStudent>();

    public virtual Program ProgramNavigation { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
