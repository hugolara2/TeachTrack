namespace TeachTrack.Model.Models;

public partial class Semester {
    public int Semesterid { get; set; }

    public string Name { get; set; } = null!;

    public string Shortname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
