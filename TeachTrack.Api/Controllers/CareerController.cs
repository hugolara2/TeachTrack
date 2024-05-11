using Microsoft.AspNetCore.Mvc;
using TeachTrack.Service.DTOs;
using TeachTrack.Service.Services;

namespace TeachTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CareerController : ControllerBase {
   private readonly ICommonService<CareerDto, CareerInsertDto, CareerUpdateDto> _service;

   public CareerController([FromKeyedServices("CareerService")] ICommonService<CareerDto, CareerInsertDto, CareerUpdateDto> service) {
      _service = service;
   }
   
   [HttpGet]
   public async Task<IEnumerable<CareerDto>> Get() => await _service.Get();

   [HttpGet("{id}")]
   public async Task<ActionResult<CareerDto>> GetById(int id) {
      var careerDto = await _service.GetById(id);
      return careerDto == null ? NotFound() : Ok(careerDto);
   }

   [HttpPost]
   public async Task<ActionResult<CareerDto>> Add(CareerInsertDto insertDto) {
      var careerDto = await _service.Add(insertDto);
      return CreatedAtAction(nameof(GetById), new { id = careerDto.Careerid }, careerDto);
   }
   
   [HttpPut("{id}")]
   public async Task<ActionResult<CareerDto>> Update(int id, CareerUpdateDto updateDto) {
      var careerDto = await _service.Update(id, updateDto);
      return careerDto == null ? NotFound() : Ok(careerDto);
   }

   [HttpDelete("{id}")]
   public async Task<ActionResult<CareerDto>> Delete(int id) {
      var careerDto = await _service.Delete(id);
      return careerDto == null ? NotFound() : NoContent();
   }
}