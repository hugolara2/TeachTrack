using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class StatusGrade
{
    public int Statusid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
