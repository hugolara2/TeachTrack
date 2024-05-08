namespace TeachTrack.Model.Models;

public partial class Career {
    public int Careerid { get; set; }

    public string Name { get; set; } = null!;

    public string Shortname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
