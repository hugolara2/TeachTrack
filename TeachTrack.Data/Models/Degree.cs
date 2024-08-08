using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Degree
{
    public short Degreeid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
