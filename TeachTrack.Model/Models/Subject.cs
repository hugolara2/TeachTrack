namespace TeachTrack.Model.Models;

public partial class Subject {
    public int Subjectid { get; set; }

    public string Name { get; set; } = null!;

    public string Shortname { get; set; } = null!;

    public int? Degreeid { get; set; }

    public int? Careerid { get; set; }

    public int? Semesterid { get; set; }

    public string? Status { get; set; }

    public virtual Career? Career { get; set; }

    public virtual Degree? Degree { get; set; }

    public virtual Semester? Semester { get; set; }
}
