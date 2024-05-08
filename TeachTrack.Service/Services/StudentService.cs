using AutoMapper;
using TeachTrack.Core.Domain.Repositories;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;

namespace TeachTrack.Service.Services;

public class StudentService : ICommonService<StudentDto, StudentInsertDto, StudentUpdateDto> {
   private readonly IRepository<Student> _repository;
   private IMapper _mapper;

   public StudentService(IRepository<Student> repository, IMapper mapper) {
      _repository = repository;
      _mapper = mapper;
   }
   
   public async Task<IEnumerable<StudentDto>> Get() {
      var student = await _repository.Get();
      return student.Select(student => _mapper.Map<StudentDto>(student));
   }

   public async Task<StudentDto> GetById(int id) {
      throw new NotImplementedException();
   }

   public async Task<StudentDto> Add(StudentInsertDto insertDto) {
      throw new NotImplementedException();
   }

   public async Task<StudentDto> Update(StudentUpdateDto updateDto) {
      throw new NotImplementedException();
   }

   public async Task<StudentDto> Delete(int id) {
      throw new NotImplementedException();
   }
}