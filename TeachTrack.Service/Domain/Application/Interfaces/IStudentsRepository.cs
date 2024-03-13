using TeachTrack.Service.Domain.Model.Students;

namespace TeachTrack.Service.Domain.Application.Interfaces;

public interface IStudentsRepository {
   List<Student> Search(string schoolEnrollment);
   
}