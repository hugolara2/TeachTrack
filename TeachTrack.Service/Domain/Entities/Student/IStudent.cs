namespace TeachTrack.Service.Domain.Entities.Student;

public interface IStudent {
   bool CanRegisterInANewCourse(float score);
}