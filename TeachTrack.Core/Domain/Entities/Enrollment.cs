using TeachTrack.Service.Domain.ValueObjects;

namespace TeachTrack.Service.Domain.Entities;

public class Enrollment {
   public int StudentId { get; set; }
   public Students Student { get; set; }
   public int SubjectId { get; set; }
   public Subjects Subject { get; set; }
   public Grade Grade { get; set; }
}