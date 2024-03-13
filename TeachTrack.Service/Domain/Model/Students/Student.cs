using TeachTrack.Service.External.Enums;
namespace TeachTrack.Service.Domain.Model.Students;

public class Student : Person.Person, IStudent {
   public string SchoolEnrollment { get; set; }
   public float Score { get; set; }
   public float Grade { get; set; }
   private readonly Score? _scores = null;

   protected Student(string name, string lastName, string schoolEnrollment, float score, float grade) : base(name, lastName) {
      SchoolEnrollment = schoolEnrollment;
      Score = score;
      Grade = grade;
   }
   
   public bool CanRegisterNewSubjects(float score) {
      
      return score >= _scores!.MinimumScore && score <= _scores!.MaximumScore;
   }
}