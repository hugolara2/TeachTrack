using TeachTrack.Service.Domain.ValueObjects;

namespace TeachTrack.Service.Domain.Entities.Student;

public class Student : Person.Person, IStudent {
   public string StudentId { get; set; }
   public float StudentScore { get; set; }
   private readonly Score _score = new Score();
   
   public Student(string studentId, string name, string lastName, float studentScore) : base(name, lastName) {
      StudentId = studentId;
      StudentScore = studentScore;
   }
   public bool CanRegisterInACourse(float score) {
      return score <= _score.MaxScore && score >= _score.MinScore;
   }
}