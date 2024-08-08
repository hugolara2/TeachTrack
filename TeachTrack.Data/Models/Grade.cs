using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class Grade
{
    public int Gradeid { get; set; }

    public int Studentid { get; set; }

    public int Subjectid { get; set; }

    public decimal Firstperiod { get; set; }

    public decimal Secondperiod { get; set; }

    public decimal Thirdperiod { get; set; }

    public decimal Finalgrade { get; set; }

    public DateOnly Gradedate { get; set; }

    public int Status { get; set; }

    public virtual StatusGrade StatusNavigation { get; set; } = null!;
}
