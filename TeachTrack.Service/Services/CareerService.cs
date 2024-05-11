using AutoMapper;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;

namespace TeachTrack.Service.Services;

public class CareerService : ICommonService<CareerDto, CareerInsertDto, CareerUpdateDto> {
   private readonly IRepository<Career> _repository;
   private readonly IMapper _mapper;

   public CareerService(IRepository<Career> repository, IMapper mapper) {
      _repository = repository;
      _mapper = mapper;
   }
   
   public async Task<IEnumerable<CareerDto>> Get() {
      var career = await _repository.Get();
      return career.Select(career => _mapper.Map<CareerDto>(career)).Where(c => c.Status == "Active");
   }

   public async Task<CareerDto> GetById(int id) {
      var career = await _repository.GetById(id);

      if (career != null) {
         var careerDto = _mapper.Map<CareerDto>(career);
         return careerDto;
      }

      return null;
   }

   public async Task<CareerDto> Add(CareerInsertDto insertDto) {
      var career = _mapper.Map<Career>(insertDto);

      await _repository.Add(career);
      await _repository.Save();

      var careerDto = _mapper.Map<CareerDto>(career);
      return careerDto;
   }

   public async Task<CareerDto> Update(int id, CareerUpdateDto updateDto) {
      var career = await _repository.GetById(id);
      
      if (career != null) {
         career = _mapper.Map<CareerUpdateDto, Career>(updateDto, career);

         _repository.Update(career);
         await _repository.Save();

         var careerDto = _mapper.Map<CareerDto>(career);
         return careerDto;
      }

      return null;
   }

   public async Task<CareerDto> Delete(int id) {
      var career = await _repository.GetById(id);

      if (career != null) {
         career.Status = "Inactive";
         
         _repository.Update(career);
         await _repository.Save();
         
         return _mapper.Map<CareerDto>(career);
      }

      return null;
   }
} 