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


       public Guid Id { get; set; }
        public string? PaymentMethod { get; set; }

        public int StatusTypeId { get; set; }

    }
}
