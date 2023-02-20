
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTClientAddressExtensionDTO
    {
        public int Id { get; set; }
        public Guid GSTClientID { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public int AddressTypeId { get; set; }
        public AddressTypeDTO AddressType { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }

    public class GSTClientAddressExtensionCreateDTO
    {
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public int AddressTypeId { get; set; }
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
        [Required]
        public int StatusId { get; set; }
    }

    public class GSTClientAddressExtensionUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public int AddressTypeId { get; set; }
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
        [Required]
        public int StatusId { get; set; }
    }


    public class ActiveGSTClientAddressForDD
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
    }
}

