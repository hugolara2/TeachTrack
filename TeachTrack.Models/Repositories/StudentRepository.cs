using TeachTrack.Core.Domain.Entities;
using TeachTrack.Core.Domain.Repositories;

namespace TeachTrack.Model.Repositories;

public class StudentRepository : IStudentRepository {
   public Task<Students> GetAsync() {
      throw new NotImplementedException();
   }

   public Task<Students> GetByIdAsync(int id) {
      throw new NotImplementedException();
   }

   public Task AddAsync(Students student) {
      throw new NotImplementedException();
   }

   public void Update(Students student) {
      throw new NotImplementedException();
   }

   public void Delete(Students student) {
      throw new NotImplementedException();
   }
}
