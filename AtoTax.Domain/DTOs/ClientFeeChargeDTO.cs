using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{

    public class ClientFeeChargeDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public double GSTMonthlySubmission { get; set; }
        public double GSTAmendment { get; set; }
        public double GSTAnnualReturnFiling { get; set; }
        public double GSTNoticeService { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
    public class ClientFeeChargeCreateDTO
    {
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public double GSTMonthlySubmission { get; set; }
        [Required]
        public double GSTAmendment { get; set; }
        [Required]
        public double GSTAnnualReturnFiling { get; set; }
        [Required]
        public double GSTNoticeService { get; set; }

    }


    public class ClientFeeChargeUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public double GSTMonthlySubmission { get; set; }
        [Required]
        public double GSTAmendment { get; set; }
        [Required]
        public double GSTAnnualReturnFiling { get; set; }
        [Required]
        public double GSTNoticeService { get; set; }

    }


}
