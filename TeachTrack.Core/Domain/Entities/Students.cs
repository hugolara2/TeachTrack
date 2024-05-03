using TeachTrack.Service.Domain.ValueObjects;

namespace TeachTrack.Service.Domain.Entities;

public class Students {
   private readonly Score _score;
   public int StudentId { get; set; }
   public string? Name { get; set; }
   public string? LastName { get; set; }
   public float Score { get; set; }
   public List<Enrollment> Enrollments { get; set; }

   public Students(int studentId, string name, string lastName, float score) {
      StudentId = studentId;
      Name = name;
      LastName = lastName;
      Score = score;
   }

   public bool StudentHasAcceptableScore(float score) =>
      score <= _score.MaxScore && score >= _score.MinScore;

   public bool CanEnrollInSubject(Subjects subject) {
      return false;
   }
}