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



            //Address Type
            CreateMap<AddressType, AddressTypeDTO>().ReverseMap();
            CreateMap<AddressTypeCreateDTO, AddressType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<AddressTypeUpdateDTO, AddressType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            //Media Type
            CreateMap<MediaType, MediaTypeDTO>().ReverseMap();
            CreateMap<MediaTypeCreateDTO, MediaType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<MediaTypeUpdateDTO, MediaType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            //Payment Type
            CreateMap<PaymentType, PaymentTypeDTO>().ReverseMap();
            CreateMap<PaymentTypeCreateDTO, PaymentType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<PaymentTypeUpdateDTO, PaymentType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //EmpJobRoles
            CreateMap<EmpJobRole, EmpJobRoleDTO>().ReverseMap();
            CreateMap<EmpJobRoleCreateDTO, EmpJobRole>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<EmpJobRoleUpdateDTO, EmpJobRole>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //Amend Type
            CreateMap<AmendType, AmendTypeDTO>().ReverseMap();
            CreateMap<AmendTypeCreateDTO, AmendType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<AmendTypeUpdateDTO, AmendType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //Amendments
            CreateMap<Amendment, AmendmentDTO>().ReverseMap();
            CreateMap<AmendmentCreateDTO, Amendment>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<AmendmentUpdateDTO, Amendment>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));




            //GSTFilingTypes
            CreateMap<GSTFilingType, GSTFilingTypeDTO>().ReverseMap();
            CreateMap<GSTFilingTypeCreateDTO, GSTFilingType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTFilingTypeUpdateDTO, GSTFilingType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            //DefaultCharges
            CreateMap<DefaultCharge, DefaultChargeDTO>().ReverseMap();
            CreateMap<DefaultChargeCreateDTO, DefaultCharge>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); 
            CreateMap<DefaultChargeUpdateDTO, DefaultCharge>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
