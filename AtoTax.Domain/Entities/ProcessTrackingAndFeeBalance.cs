using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class ProcessTrackingAndFeeBalance
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }

        [ForeignKey("ReturnFrequencyType")]
        public int ReturnFrequencyTypeId { get; set; }
        public virtual ReturnFrequencyType ReturnFrequencyType { get; set; }
        public string DueMonth { get; set; }
        public int DueYear { get; set; }
        public string RackFileNo { get; set; }
        public bool? SalesInvoice { get; set; }
        public bool? SalesBillsNil { get; set; }
        public bool? PurchaseInvoice { get; set; }
        public bool? PurchaseNil { get; set; }
        public double? GSTTaxAmount { get; set; }
        public double? FeesAmount { get; set; }
        public double? AmountPaid { get; set; }
        public double? CurrentBalance { get; set; }
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
}
