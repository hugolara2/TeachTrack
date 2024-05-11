using AutoMapper;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;

namespace TeachTrack.Service.Services;

public class DegreeService : IBasicService<DegreeDto> {
   private readonly IBasicRepository<Degree> _repository;
   private readonly IMapper _mapper;

   public DegreeService(IBasicRepository<Degree> repository, IMapper mapper) {
      _repository = repository;
      _mapper = mapper;
   }
   
   public async Task<IEnumerable<DegreeDto>> Get() {
      var degree = await _repository.Get();
      return degree.Select(degree => _mapper.Map<DegreeDto>(degree));
   }

   public async Task<DegreeDto> GetById(int id) {
      var degree = await _repository.GetById(id);

      if (degree != null) {
         var degreeDto = _mapper.Map<DegreeDto>(degree);
         return degreeDto;
      }

      return null;
   }
}