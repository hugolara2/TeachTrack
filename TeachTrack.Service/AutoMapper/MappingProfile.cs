using AutoMapper;
using TeachTrack.Model.Models;
using TeachTrack.Service.DTOs;

namespace TeachTrack.Service.AutoMapper;

public class MappingProfile : Profile {
   public MappingProfile() {
      //Student mapper
      CreateMap<StudentInsertDto, Student>();
      CreateMap<Student, StudentDto>()
         .ForMember(s => s.Studentid,
            m => m.MapFrom(student => student.Studentid));
      CreateMap<StudentUpdateDto, Student>();
      //Career mapper
      CreateMap<CareerInsertDto, Career>();
      CreateMap<Career, CareerDto>()
         .ForMember(c => c.Careerid,
            m => m.MapFrom(career => career.Careerid));
      CreateMap<CareerUpdateDto, Career>(); 
      //Degree
      CreateMap<Degree, DegreeDto>()
         .ForMember(d => d.Degreeid,
            m => m.MapFrom(degree => degree.Degreeid));
   }
}