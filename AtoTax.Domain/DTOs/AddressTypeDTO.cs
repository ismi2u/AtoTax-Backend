
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class AddressTypeDTO
    {
        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int StatusId { get; set; }
    }

    public class AddressTypeCreateDTO
    {
        [Required]
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }
        [Required]
        public int StatusId { get; set; }
    }

    public class AddressTypeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
