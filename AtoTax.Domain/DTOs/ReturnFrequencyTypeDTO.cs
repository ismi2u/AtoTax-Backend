using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AtoTax.Domain.Entities;

namespace AtoTax.Domain.DTOs
{

    public class ReturnFrequencyTypeDTO
    {
        public int Id { get; set; }
        public string ReturnFreqType { get; set; }

        public string Description { get; set; }
        public double FixedCharge { get; set; }
        public double? PreviousCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }
    public class ReturnFrequencyTypeCreateDTO
    {
        public string ReturnFreqType { get; set; }

        public string Description { get; set; }
        public double FixedCharge { get; set; }
        public double? PreviousCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? StatusId { get; set; }

    }


    public class ReturnFrequencyTypeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string ReturnFreqType { get; set; }

        public string Description { get; set; }
        public double FixedCharge { get; set; }
        public double? PreviousCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? StatusId { get; set; }
    }

    public class ClientReturnFrequencyForDD
    {
        public int Id { get; set; }
        public string ReturnFreqType { get; set; }
    }

}
