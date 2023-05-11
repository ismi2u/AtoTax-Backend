using AtoTax.Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class QuaterlyFiling
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
        public string? DueQuater { get; set; }
        public int? DueYear { get; set; }
        public string? FiscalYear { get; set; }
        public string RackFileNo { get; set; }

        public double? SalesTaxable { get; set; }
        public double? SalesCGST { get; set; }
        public double? SalesSGST { get; set; }
        public double? SalesIGST { get; set; }
        public bool? SalesInvoice { get; set; }
        public bool? SalesBillsNil { get; set; }

        public double? PurchaseTaxable { get; set; }
        public double? PurchaseCGST { get; set; }
        public double? PurchaseSGST { get; set; }
        public double? PurchaseIGST { get; set; }
        public bool? PurchaseInvoice { get; set; }
        public bool? PurchaseNil { get; set; }

        public string? ReceivedByUser { get; set; }
        public double? GSTTaxAmount { get; set; }
        public double? ServiceFee { get; set; }
        public double? ServiceFeeReceived { get; set; }
        public double? ServiceFeeBalance { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool? SalesFiled { get; set; }
        public bool? SalesNotFiled { get; set; }
        public bool? SalesNilFiled { get; set; }
        public bool? SalesNilNotFiled { get; set; }
        public DateTime? SalesFiledDate { get; set; }
        public string? GSTR1FiledByUser { get; set; }
        public bool? GSTR3BFiled { get; set; }
        public bool? GSTR3BNotFiled { get; set; }
        public bool? GSTR3BNILFiled { get; set; }
        public bool? GSTR3BNilNotFiled { get; set; }
        public DateTime? GSTR3BFiledDate { get; set; }
        public string? GSTR3BFiledByUser { get; set; }

    }
}

