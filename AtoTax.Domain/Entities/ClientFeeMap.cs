﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class ClientFeeMap
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }

        [Required]
        [ForeignKey("ReturnFrequencyType")]
        public int ReturnFrequencyTypeId { get; set; }
        public virtual ReturnFrequencyType ReturnFrequencyType { get; set; }

        [Required]
        public double DefaultCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
