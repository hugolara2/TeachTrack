using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;

namespace TeachTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase {
   private TeachTrackContext _context;

   public StudentController(TeachTrackContext context) {
      _context = context;
   }

   [HttpGet]
   public async Task<IEnumerable<Student>> Get() => 
      await _context.Students.ToListAsync();
}