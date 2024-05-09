using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using TeachTrack.Model.DBContext;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;
using TeachTrack.Service.Services;

namespace TeachTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase {
   private ICommonService<StudentDto, StudentInsertDto, StudentUpdateDto> _service;

   public StudentController([FromKeyedServices("StudentService")] ICommonService<StudentDto, StudentInsertDto, StudentUpdateDto> service) {
      _service = service;
   }

   [HttpGet]
   public async Task<IEnumerable<StudentDto>> Get() =>
      await _service.Get();

   [HttpGet("{id}")]
   public async Task<ActionResult<StudentDto>> GetById(int id) {
      var studentDto = await _service.GetById(id);
      return studentDto == null ? NotFound() : Ok(studentDto);
   }
}