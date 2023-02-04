using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class GSTClientAddressExtension
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int GSTClientId { get; set; }
        [Required]
        [ForeignKey("AddressType")]
        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        [Required]
        public string City { get; set; }
        public string? District { get; set; }
        [Required]
        public string State { get; set; }
   
        public string? Pincode { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }


    }
}
