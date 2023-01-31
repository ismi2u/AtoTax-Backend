using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class CreateClientFeeChargeDTO
    {
        public Guid GSTClientId { get; set; }
        public double GSTMonthlySubmission { get; set; }
        public double GSTAmendment { get; set; }
        public double GSTAnnualReturnFiling { get; set; }
        public double GSTNoticeService { get; set; }

    }

    public class GetClientFeeChargeDTO
    {
        public Guid Id { get; set; }
        public int GSTClientId { get; set; }
        public double GSTMonthlySubmission { get; set; }
        public double GSTAmendment { get; set; }
        public double GSTAnnualReturnFiling { get; set; }
        public double GSTNoticeService { get; set; }

    }

    public class UpdateClientFeeChargeDTO
    {
        public Guid Id { get; set; }
        public int GSTClientId { get; set; }
        public double GSTMonthlySubmission { get; set; }
        public double GSTAmendment { get; set; }
        public double GSTAnnualReturnFiling { get; set; }
        public double GSTNoticeService { get; set; }

    }

    public class RemoveClientFeeChargeDTO
    {
        public Guid Id { get; set; }
    }

}
