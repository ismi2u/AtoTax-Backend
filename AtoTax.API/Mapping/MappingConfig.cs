using AtoTax.API.Authentication;
using AtoTax.API.Controllers;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.DTOs.AuthDTOs;
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
            CreateMap<GSTClient, ActiveGSTClientsForDD>()
                .ForMember(dest => dest.GSTClientAndGSTIN, opt => opt.MapFrom(src => src.GetGSTClient())); ;

            //Status
            CreateMap<Status, StatusDTO>().ReverseMap();

            //ApprovalStatusTypes
            CreateMap<ApprovalStatusType, ApprovalStatusTypeDTO>().ReverseMap();

            //Account Ledger
            CreateMap<AccountLedger, AccountLedgerDTO>().ReverseMap();
            CreateMap<AccountLedgerCreateDTO, AccountLedger>()
               .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //ReturnFrequencyType
            CreateMap<ReturnFrequencyType, ReturnFrequencyTypeDTO>().ReverseMap();
            CreateMap<ReturnFrequencyTypeDTO, ReturnFrequencyType>();
              

            //Address Type
            CreateMap<AddressType, AddressTypeDTO>().ReverseMap();
            CreateMap<AddressTypeCreateDTO, AddressType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<AddressTypeUpdateDTO, AddressType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<AddressType, ActiveAddressTypeForDD>();


            //Multimedia Type
            CreateMap<MultimediaType, MultimediaTypeDTO>().ReverseMap();
            CreateMap<MultimediaTypeCreateDTO, MultimediaType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<MultimediaTypeUpdateDTO, MultimediaType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<MultimediaType, ActiveMultimediaTypeForDD>()
              .ForMember(dest => dest.MediaAndDesc, opt => opt.MapFrom(src => src.GetMultimedia()));

            //Payment Type
            CreateMap<PaymentType, PaymentTypeDTO>().ReverseMap();
            CreateMap<PaymentTypeCreateDTO, PaymentType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<PaymentTypeUpdateDTO, PaymentType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<PaymentType, ActivePaymentTypeForDD>();
                



            //Amend Type
            CreateMap<AmendType, AmendTypeDTO>().ReverseMap();
            CreateMap<AmendTypeCreateDTO, AmendType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)); ;
            CreateMap<AmendTypeUpdateDTO, AmendType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<AmendType, ActiveAmendTypeForDD>();


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
            CreateMap<GSTFilingType, ActiveGSTFilingTypeForDD>();


            //ReturnFrequencyType
            CreateMap<ReturnFrequencyType, ReturnFrequencyTypeDTO>().ReverseMap();
            CreateMap<ReturnFrequencyTypeCreateDTO, ReturnFrequencyType>()
             .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ReturnFrequencyTypeUpdateDTO, ReturnFrequencyType>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            //CreateMap<ReturnFrequencyType, ActiveReturnFrequencyTypeForDD>()
            //   .ForMember(dest => dest.ServiceNameAndDesc, opt => opt.MapFrom(src => src.GetReturnFrequencyType()));


            //ClientFeeMaps
            CreateMap<ClientFeeMap, ClientFeeMapDTO>().ReverseMap();
            CreateMap<ClientFeeMapCreateDTO, ClientFeeMap>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ClientFeeMapUpdateDTO, ClientFeeMap>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<ClientMonthlyPayment, ClientMonthlyPaymentDTO>().ReverseMap();
            CreateMap<ClientMonthlyPaymentCreateDTO, ClientMonthlyPayment>()
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //GSTClientAddressExtension
            CreateMap<GSTClientAddressExtension, GSTClientAddressExtensionDTO>().ReverseMap();
            CreateMap<GSTClientAddressExtensionCreateDTO, GSTClientAddressExtension>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTClientAddressExtensionUpdateDTO, GSTClientAddressExtension>()
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTClientAddressExtension, ActiveGSTClientAddressForDD>()
               .ForMember(dest => dest.AddressType, opt => opt.MapFrom(src => src.AddressType.AddressTypeName));


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



            //ProcessTrackingAndFeeBalance
            CreateMap<ProcessTrackingAndFeeBalance, ProcessTrackingAndFeeBalanceDTO>().ReverseMap();
            //CreateMap<ProcessTrackingAndFeeBalanceCreateDTO, ProcessTrackingAndFeeBalance>().ReverseMap();

            //AccountLedger
            CreateMap<AccountLedger, AccountLedgerDTO>().ReverseMap();
            CreateMap<AccountLedgerCreateDTO, AccountLedger>()
                 .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                 .ForMember(dest => dest.IsGSTClientPaid, opt => opt.MapFrom(src => false));

            //GSTBillsProcessing
            CreateMap<GSTBillsProcessing, GSTBillsProcessingDTO>().ReverseMap();
            CreateMap<GSTBillsProcessingCreateDTO, GSTBillsProcessing>()
                .ForMember(dest => dest.ReceivedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<GSTBillsProcessingUpdateDTO, GSTBillsProcessing>()
                .ForMember(dest => dest.FiledDate, opt => opt.MapFrom(src => DateTime.UtcNow));


            //ServiceChargeUpdateHistory
            CreateMap<ServiceChargeUpdateHistory, ServiceChargeUpdateHistoryDTO>().ReverseMap();
            CreateMap<ServiceChargeUpdateHistoryCreateDTO, ServiceChargeUpdateHistory>().ReverseMap();
            CreateMap<ClientFeeMapUpdateDTO, ServiceChargeUpdateHistory>();




            //GSTPaidDetail
            CreateMap<GSTPaidDetail, GSTPaidDetailDTO>().ReverseMap();
            CreateMap<GSTPaidDetailCreateDTO, GSTPaidDetail>().ReverseMap();
            CreateMap<GSTPaidDetailUpdateDTO, GSTPaidDetail>().ReverseMap();

            //UserLoggedActivity
            CreateMap<UserLoggedActivity, UserLoggedActivityDTO>().ReverseMap();
            CreateMap<UserLoggedActivityCreateDTO, UserLoggedActivity>().ReverseMap();

            /////
            ///>>>>>>>>>>>>>>>END>>>>>>>>>>>>>>>>>>>>>>>>>>


            //RegistrationRequest
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            











        }
    }
}
