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
      return student.Select(student => _mapper.Map<StudentDto>(student)).Where(s => s.Status == "Active");
   }

   public async Task<StudentDto> GetById(int id) {
      var student = await _repository.GetById(id);

      if (student != null) {
         var studentDto = _mapper.Map<StudentDto>(student);
         return studentDto;
      }
      
      return null;
   }

   public async Task<StudentDto> Add(StudentInsertDto insertDto) {
      var student = _mapper.Map<Student>(insertDto);

      await _repository.Add(student);
      await _repository.Save();

      var studentDto = _mapper.Map<StudentDto>(student);
      return studentDto;
   }

   public async Task<StudentDto> Update(int id, StudentUpdateDto updateDto) {
      var student = await _repository.GetById(id);

      if (student != null) {
         student = _mapper.Map<StudentUpdateDto, Student>(updateDto, student);
         
         _repository.Update(student);
         await _repository.Save();

         var studentDto = _mapper.Map<StudentDto>(student);
         return studentDto;
      }

      return null;
   }

   public async Task<StudentDto> Delete(int id) {
      var student = await _repository.GetById(id);

      if (student != null) {
         student.Status = "Inactive";
         _repository.Update(student);
         await _repository.Save();
         return _mapper.Map<StudentDto>(student);
      }

      return null;
   }
}