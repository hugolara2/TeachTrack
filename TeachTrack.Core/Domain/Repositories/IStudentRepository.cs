using TeachTrack.Core.Domain.Entities;

namespace TeachTrack.Core.Domain.Repositories;

public interface IStudentRepository {
   Task<Students> GetAsync();
   Task<Students> GetByIdAsync(int id);
   Task AddAsync(Students student);
   void Update(Students student);
   void Delete(Students student);
}