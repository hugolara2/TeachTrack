using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Program
{
    public int Programid { get; set; }

    public short Degree { get; set; }

    public string Name { get; set; } = null!;

    public string Programcode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Degree DegreeNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
