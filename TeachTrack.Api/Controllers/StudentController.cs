using Microsoft.AspNetCore.Mvc;
using TeachTrack.Service.DTOs;
using TeachTrack.Service.Services;

namespace TeachTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase {
   private readonly ICommonService<StudentDto, StudentInsertDto, StudentUpdateDto> _service;

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

   [HttpPost]
   public async Task<ActionResult<StudentDto>> Add(StudentInsertDto insertDto) {
      var studentDto = await _service.Add(insertDto);
      return CreatedAtAction(nameof(GetById), new { id = studentDto.Studentid }, studentDto);
   }

   [HttpPut("{id}")]
   public async Task<ActionResult<StudentDto>> Update(int id, StudentUpdateDto updateDto) {
      var studentDto = await _service.Update(id, updateDto);
      return studentDto == null ? NotFound() : Ok(studentDto);
   }
   
   [HttpDelete("{id}")]
   public async Task<ActionResult<StudentDto>> Delete(int id) {
      var studentDto = await _service.Delete(id);
      return studentDto == null ? NotFound() : NoContent();
   }
}