using TeachTrack.Service.Domain.Entities.Student;

namespace TeachTrack.Service.Domain.Services;

public interface IRegistrationService {
   bool CanRegisterInNewCourse(string studentId, string courseId);
}