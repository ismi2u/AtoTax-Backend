
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class DefaultChargeDTO
    {
        public int Id { get; set; }
        [Required]
        public string GSTClientServiceType { get; set; }
        public double FeeAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }


    public class DefaultChargeCreateDTO
    {
        [Required]
        public string GSTClientServiceType { get; set; }
        [Required]
        public double FeeAmount { get; set; }
    }


    public class DefaultChargeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GSTClientServiceType { get; set; }
        [Required]
        public double FeeAmount { get; set; }
    }
}
