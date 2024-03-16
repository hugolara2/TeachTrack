using TeachTrack.Service.Domain.Entities.Course;
using TeachTrack.Service.Domain.Entities.Student;
using TeachTrack.Service.Domain.Repositories;

namespace TeachTrack.Service.Domain.Services;

public class RegistrationService : IRegistrationService {
   private readonly IStudentRepository _studentRepository;
   private readonly ICourseRepository _courseRepository;

   public RegistrationService(IStudentRepository studentRepository, ICourseRepository courseRepository) {
      _studentRepository = studentRepository;
      _courseRepository = courseRepository;
   }
   
   public bool CanRegisterInNewCourse(string studentId, string courseId) {
      Student student = _studentRepository.GetStudentById(studentId);
      Course course = _courseRepository.GetCoursesById(courseId);

      if (student == null)
         throw new ArgumentException("Student not found");
      if (course == null)
         throw new ArgumentException("Course not found");

      return student.CanRegisterInACourse(student.StudentScore);
   }
}