using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class PaymentTypeDTO
    {
        public int Id { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int StatusId { get; set; }

    }

    public class PaymentTypeCreateDTO
    {
        [Required]
        public string? PaymentMethod { get; set; }
        [Required]
        public int StatusId { get; set; }

    }

    public class PaymentTypeUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string? PaymentMethod { get; set; }
        [Required]
        public int StatusId { get; set; }

    }
}
