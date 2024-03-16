using TeachTrack.Service.Domain.Entities.Student;

namespace TeachTrack.Service.Domain.Repositories;

public interface IStudentRepository {
   List<Student> GetStudents();
   Student GetStudentById(string studentId);
   void Save();
}