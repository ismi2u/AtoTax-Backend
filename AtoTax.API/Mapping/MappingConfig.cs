using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using AutoMapper;

namespace AtoTax.API.Mapping
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<GSTClient, GSTClientDTO>().ReverseMap();
            CreateMap<GSTClientCreateDTO, GSTClient>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTClientUpdateDTO, GSTClient>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<StatusCreateDTO, Status>().ReverseMap();
            //
        }
    }
}
