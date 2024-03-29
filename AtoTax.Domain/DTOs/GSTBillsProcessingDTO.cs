﻿using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTBillsProcessingDTO
    {

        public Guid Id { get; set; }
        public Guid GSTClientID { get; set; }
        public GSTClientDTO GSTClient { get; set; }

        public int ReturnFrequencyTypeId { get; set; }
        public ReturnFrequencyTypeDTO ReturnFrequencyType { get; set; }
        public string DueMonth { get; set; }
        public int DueYear { get; set; }
        public int GSTFilingTypeId { get; set; }
        public GSTFilingTypeDTO GSTFilingType { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int MultimediaTypeId { get; set; }
        public MultimediaTypeDTO MultimediaType { get; set; }
        public string FiledBy { get; set; }
        public DateTime? FiledDate { get; set; }
        public bool IsBillsReceived { get; set; }
        public bool IsFiled { get; set; }
        //public double FeesAmount { get; set; }
        //public double FeesPaidAmt { get; set; }
        //public double Balance { get; set; }
        public bool ReceivedAckEmailSent { get; set; }
        public bool GSTFiledAckEmailSent { get; set; }
        public bool ReceivedAckSMSSent { get; set; }
        public bool GSTFiledAckSMSSent { get; set; }

    }

    public class GSTBillsProcessingCreateDTO
    {
        [Required]
        public Guid GSTClientID { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int DueYear { get; set; }
        [Required]
        public int GSTFilingTypeId { get; set; }

        [Required]
        public int MultimediaTypeId { get; set; }
        //public Guid? FiledBy { get; set; }
        //public DateTime? FiledDate { get; set; }

        //public bool IsBillsReceived { get; set; }
        ////public bool IsFiled { get; set; }
        //public double FeesAmount { get; set; }
        //public double FeesPaidAmt { get; set; }
        //public double Balance { get; set; }
        //public bool ReceivedAckEmailSent { get; set; }
        //public bool GSTFiledAckEmailSent { get; set; }
        //public bool ReceivedAckSMSSent { get; set; }
        //public bool GSTFiledAckSMSSent { get; set; }

    }

    public class GSTBillsProcessingUpdateDTO
    {
        public Guid Id { get; set; }

        public Guid GSTClientID { get; set; }
        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int DueYear { get; set; }

        //public bool ReceivedAckEmailSent { get; set; }
        //public bool GSTFiledAckEmailSent { get; set; }
        //public bool ReceivedAckSMSSent { get; set; }
        //public bool GSTFiledAckSMSSent { get; set; }

    }

}
