using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Desk, DeskToReturnDto>()
            .ForMember(d => d.Room, o => o.MapFrom(s => s.Room.Name))
            .ForMember(d => d.QrCodeUrl, o => o.MapFrom<DeskUrlResolver>());
        }

    }
}