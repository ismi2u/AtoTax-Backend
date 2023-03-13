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

    //used in ClientMonthlyPayments 
    
    //public class ClientApplicableReturnsDTO
    //{
    //    public Guid GSTClientId { get; set; }

    //    public List<ClientFrequencyForDD> Frequencies { get; set; }

    //}

    
}
