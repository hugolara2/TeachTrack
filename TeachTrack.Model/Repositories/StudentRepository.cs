using Microsoft.EntityFrameworkCore;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;

namespace TeachTrack.Model.Repositories;

public class StudentRepository : IRepository<Student> {

   private TeachTrackContext _context;

   public StudentRepository(TeachTrackContext context) {
      _context = context;
   }

   public async Task<IEnumerable<Student>> Get() => await _context.Students.ToListAsync();

   public async Task<Student> GetById(int id) => await _context.Students.FindAsync(id);

   public async Task Add(Student student) => await _context.Students.AddAsync(student);

   public void Update(Student student) {
      _context.Students.Attach(student);
      _context.Students.Entry(student).State = EntityState.Modified;
   }

   public void Delete(Student student) => _context.Remove(student);

   public async Task Save() => await _context.SaveChangesAsync();
}
