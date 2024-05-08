namespace TeachTrack.Model.Models;

public partial class Student {
    public int Studentid { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public decimal Score { get; set; }

    public int? Degreeid { get; set; }

    public int? Careerid { get; set; }

    public int? Semesterid { get; set; }

    public string? Status { get; set; }

    public virtual Career? Career { get; set; }

    public virtual Degree? Degree { get; set; }

    public virtual Semester? Semester { get; set; }
}
