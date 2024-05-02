namespace TeachTrack.Model.Models;

public partial class SubjectSchedule {
    public int Scheduleid { get; set; }

    public int Subjectid { get; set; }

    public string Schedule { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Status { get; set; }
}
