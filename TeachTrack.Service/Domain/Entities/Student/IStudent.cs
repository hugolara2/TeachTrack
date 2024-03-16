namespace TeachTrack.Service.Domain.Entities.Student;

public interface IStudent {
   bool CanRegisterInACourse(float score);
}