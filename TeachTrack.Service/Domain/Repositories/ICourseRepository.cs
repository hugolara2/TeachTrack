using TeachTrack.Service.Domain.Entities.Course;

namespace TeachTrack.Service.Domain.Repositories;

public interface ICourseRepository {
   List<Course> GetCourses();
   Course GetCoursesById(string courseId);
   void Save();
}