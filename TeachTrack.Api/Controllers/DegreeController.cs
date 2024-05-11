using Microsoft.AspNetCore.Mvc;
using TeachTrack.Service.DTOs;
using TeachTrack.Service.Services;

namespace TeachTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DegreeController : ControllerBase {

   private readonly IBasicService<DegreeDto> _service;

   public DegreeController([FromKeyedServices("DegreeService")] IBasicService<DegreeDto> service) {
      _service = service;
   }

   [HttpGet]
   public async Task<IEnumerable<DegreeDto>> Get() => await _service.Get();

   [HttpGet("{id}")]
   public async Task<ActionResult<DegreeDto>> GetById(int id) {
      var degreeDto = await _service.GetById(id);
      return degreeDto == null ? NotFound() : Ok(degreeDto);
   }
   
}