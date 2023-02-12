using AtoTax.API.Controllers;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using AutoMapper;

namespace AtoTax.API.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            //GSTClient
            CreateMap<GSTClient, GSTClientDTO>().ReverseMap();
            CreateMap<GSTClientCreateDTO, GSTClient>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTClientUpdateDTO, GSTClient>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //Status
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
            CreateMap<MultimediaType, MultimediaTypeDTO>().ReverseMap();
            CreateMap<MultimediaTypeCreateDTO, MultimediaType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<MultimediaTypeUpdateDTO, MultimediaType>()
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


            //ServiceCategory
            CreateMap<ServiceCategory, ServiceCategoryDTO>().ReverseMap();
            CreateMap<ServiceCategoryCreateDTO, ServiceCategory>()
             .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ServiceCategoryUpdateDTO, ServiceCategory>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //ClientFeeMaps
            CreateMap<ClientFeeMap, ClientFeeMapDTO>().ReverseMap();
            CreateMap<ClientFeeMapCreateDTO, ClientFeeMap>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ClientFeeMapUpdateDTO, ClientFeeMap>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            //Employee
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeCreateDTO, Employee>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<EmployeeUpdateDTO, Employee>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //GSTClientAddressExtension
            CreateMap<GSTClientAddressExtension, GSTClientAddressExtensionDTO>().ReverseMap();
            CreateMap<GSTClientAddressExtensionCreateDTO, GSTClientAddressExtension>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTClientAddressExtensionUpdateDTO, GSTClientAddressExtension>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            //GSTFilingType
            CreateMap<GSTFilingType, GSTFilingTypeDTO>().ReverseMap();
            CreateMap<GSTFilingTypeCreateDTO, GSTFilingType>()
                 .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTFilingTypeUpdateDTO, GSTFilingType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            //////>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //////>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ///>>>>>>>>>>>>>>>>> START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //////>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //////>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



            //CollectionAndBalance
            CreateMap<CollectionAndBalance, CollectionAndBalanceDTO>().ReverseMap();
            CreateMap<CollectionAndBalanceCreateDTO, CollectionAndBalance>().ReverseMap();

            //FeeCollectionLedger
            CreateMap<FeeCollectionLedger, FeeCollectionLedgerDTO>().ReverseMap();
            CreateMap<FeeCollectionLedgerCreateDTO, FeeCollectionLedger>().ReverseMap();

            //GSTBillAndFeeCollection
            CreateMap<GSTBillAndFeeCollection, GSTBillAndFeeCollectionDTO>().ReverseMap();
            CreateMap<GSTBillAndFeeCollectionCreateDTO, GSTBillAndFeeCollection>().ReverseMap();


            //ServiceChargeUpdateHistory
            CreateMap<ServiceChargeUpdateHistory, ServiceChargeUpdateHistoryDTO>().ReverseMap();
            CreateMap<ServiceChargeUpdateHistoryCreateDTO, ServiceChargeUpdateHistory>().ReverseMap();




            //GSTPaidDetail
            CreateMap<GSTPaidDetail, GSTPaidDetailDTO>().ReverseMap();
            CreateMap<GSTPaidDetailCreateDTO, GSTPaidDetail>().ReverseMap();


            //UserLoggedActivity
            CreateMap<UserLoggedActivity, UserLoggedActivityDTO>().ReverseMap();
            CreateMap<UserLoggedActivityCreateDTO, UserLoggedActivity>().ReverseMap();

            /////
            ///>>>>>>>>>>>>>>>END>>>>>>>>>>>>>>>>>>>>>>>>>>




           

           





        }
    }
}
