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
            CreateMap<GSTClient, GSTClientCreateDTO > ();
            CreateMap<GSTClient, GSTClientUpdateDTO>();
           
        }
    }
}
