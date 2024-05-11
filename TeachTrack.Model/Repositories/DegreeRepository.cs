using Microsoft.EntityFrameworkCore;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;

namespace TeachTrack.Model.Repositories;

public class DegreeRepository : IBasicRepository<Degree> {

   private readonly TeachTrackContext _context;

   public DegreeRepository(TeachTrackContext context) {
      _context = context;
   }

   public async Task<IEnumerable<Degree>> Get() => await _context.Degrees.ToListAsync();

   public async Task<Degree> GetById(int id) => await _context.Degrees.FindAsync(id);
}