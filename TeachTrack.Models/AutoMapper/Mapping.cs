using AutoMapper;
using TeachTrack.Core.Domain.Entities;
using TeachTrack.Model.Models;

namespace TeachTrack.Model.AutoMapper;

public class Mapping : Profile {
   public Mapping() {
      CreateMap<Students, Student>();
   }
}