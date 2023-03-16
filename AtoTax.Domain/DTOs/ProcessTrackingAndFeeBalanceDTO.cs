using AtoTax.Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class ProcessTrackingAndFeeBalanceDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public int FrequencyId { get; set; }
        public ReturnFrequencyTypeDTO Frequency { get; set; }
        public string DueMonth { get; set; }
        public int DueYear { get; set; }
        public string RackFileNo { get; set; }
        public bool? SalesInvoice { get; set; }
        public bool? SalesBillsNil { get; set; }
        public bool? PurchaseInvoice { get; set; }
        public bool? PurchaseNil { get; set; }
        public string GSTTaxAmount { get; set; }
        public string FeesAmount { get; set; }
        public string AmountPaid { get; set; }
        public string CurrentBalance { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ReceivedByUser { get; set; }
        public bool? SalesFiled { get; set; }
        public bool? SalesNotFiled { get; set; }
        public bool? SalesNilFiled { get; set; }
        public bool? SalesNilNotFiled { get; set; }
        public DateTime? SalesFiledDate { get; set; }
        public bool? GSTR3BFiled { get; set; }
        public bool? GSTR3BNotFiled { get; set; }
        public bool? GSTR3BNILFiled { get; set; }
        public bool? GSTR3BNilNotFiled { get; set; }
        public DateTime? GSTR3BFiledDate { get; set; }

    }
public class ProcessTrackingForReceivedDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public int ReturnFrequencyTypeId { get; set; }
        public ReturnFrequencyTypeDTO ReturnFrequencyType { get; set; }
        public string DueMonth { get; set; }
        public int DueYear { get; set; }
        public string RackFileNo { get; set; }
        public bool? SalesInvoice { get; set; }
        public bool? SalesBillsNil { get; set; }
        public bool? PurchaseInvoice { get; set; }
        public bool? PurchaseNil { get; set; }
        public string GSTTaxAmount { get; set; }
        public string FeesAmount { get; set; }
        public string AmountPaid { get; set; }
        public string CurrentBalance { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool? SalesFiled { get; set; }
        public bool? SalesNotFiled { get; set; }
        public bool? SalesNilFiled { get; set; }
        public bool? SalesNilNotFiled { get; set; }
        public DateTime? SalesFiledDate { get; set; }
        public bool? GSTR3BFiled { get; set; }
        public bool? GSTR3BNotFiled { get; set; }
        public bool? GSTR3BNILFiled { get; set; }
        public bool? GSTR3BNilNotFiled { get; set; }
        public DateTime? GSTR3BFiledDate { get; set; }

    }

    //used in GetProcessPopupDataForGSTClient 

    public class GSTClientPopupDataDTO
    {

        public Guid GSTClientId { get; set; }

        public string PropreitorName { get; set; }

        public double TotalPendingBalance { get; set; }

        public string RackFileNo { get; set; }

        public string TallyDataFilePath { get; set; }

        public double CurrentFees { get; set; }

        public string ReturnFrequency { get; set; }

        public string ClientRelationMgr { get; set; }


    }

    public class GSTClientIdAndFreqIdTO
    {
        public Guid GSTClientId { get; set; }
        public int FrequencyId { get; set; }
    }


        public class GetFrequencyInputDTO
    {

        public Guid GSTClientId { get; set; }

        //public List<string> DueMonths { get; set; }

        public List<ClientReturnFrequencyForDD> listReturnFreqTypes { get; set; }


    }

    public class GetYearsInputDTO
    {
        public Guid GSTClientId { get; set; }

        public int ReturnFrequencyTypeId { get; set; }

        public List<int> Years { get; set; }


    }

    public class UpdateS1ProcessDataDTO
    {
        public Guid GSTClientId { get; set; }
        public string DueMonth { get; set; }
        public int ReturnFrequencyTypeId { get; set; }
        public bool? SalesInvoice { get; set; }
        public bool? SalesBillsNil { get; set; }
        public bool? PurchaseInvoice { get; set; }
        public bool? PurchaseNil { get; set; }

        public double? GSTTaxAmount { get;set; }
        public double? AmountPaid { get; set; }

    }


    public class MonthObject
    {
        public int iMonth { get; set; }

        public string sMonth { get; set; }

    }
}

