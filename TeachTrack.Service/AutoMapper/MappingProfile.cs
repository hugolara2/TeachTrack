using AutoMapper;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;

namespace TeachTrack.Service.AutoMapper;

public class MappingProfile : Profile {
   public MappingProfile() {
      CreateMap<StudentInsertDto, Student>();
      CreateMap<Student, StudentDto>()
         .ForMember(s => s.Studentid,
            m => m.MapFrom(student => student.Studentid));
      CreateMap<StudentUpdateDto, Student>();
   }
}