﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class ClientFeeCharge
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int GSTClientId { get; set; }
        [Required]
        public double GSTMonthlySubmission { get; set; }
        [Required]
        public double GSTAmendment { get; set; }
        [Required]
        public double GSTAnnualReturnFiling { get; set; }
        [Required]
        public double GSTNoticeService { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
