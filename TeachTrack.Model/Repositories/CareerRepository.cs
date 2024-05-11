using Microsoft.EntityFrameworkCore;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;

namespace TeachTrack.Model.Repositories;

public class CareerRepository : IRepository<Career> {

   private readonly TeachTrackContext _context;

   public CareerRepository(TeachTrackContext context) {
      _context = context;
   }

   public async Task<IEnumerable<Career>> Get() => await _context.Careers.ToListAsync();

   public async Task<Career> GetById(int id) => await _context.Careers.FindAsync(id);

   public async Task Add(Career career) => await _context.Careers.AddAsync(career);

   public void Update(Career career) {
      _context.Careers.Attach(career);
      _context.Careers.Entry(career).State = EntityState.Modified;
   }

   public async Task Save() => await _context.SaveChangesAsync();
}