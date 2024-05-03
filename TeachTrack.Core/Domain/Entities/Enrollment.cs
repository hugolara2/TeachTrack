using TeachTrack.Core.Domain.ValueObjects;

namespace TeachTrack.Core.Domain.Entities;

public class Enrollment {
   public int StudentId { get; set; }
   public Students Student { get; set; }
   public int SubjectId { get; set; }
   public Subjects Subject { get; set; }
   public Grade Grade { get; set; }
}