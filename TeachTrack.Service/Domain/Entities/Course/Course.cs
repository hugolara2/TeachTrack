namespace TeachTrack.Service.Domain.Entities.Course;

public class Course {
   public string CourseId { get; set; }
   public string Name { get; set; }
   public List<string> Schedule { get; set; }
   public int Semester { get; set; }

   public Course(string courseId, string name, int semester) {
      CourseId = courseId;
      Name = name;
      Semester = semester;
      Schedule = new List<string>();
   }
}