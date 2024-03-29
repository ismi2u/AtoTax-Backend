﻿using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{

    public class GSTClientDTO
    {


        public Guid Id { get; set; }
        public string? ProprietorName { get; set; }

        public string? GSTIN { get; set; }
        public bool isRegular { get; set; }
        public string? ContactName { get; set; }
        public string? GSTUserName { get; set; }
        public string? GSTUserPassword { get; set; }
        public DateTime? GSTRegDate { get; set; }
        public DateTime? GSTSurrenderedDate { get; set; }
        public DateTime? GSTRelievedDate { get; set; }
        public double? GSTAnnualTurnOver { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactEmailId { get; set; }
        public string? GSTEmailId { get; set; }
        public string? GSTEmailPassword { get; set; }
        public string? GSTRecoveryEmailId { get; set; }
        public string? GSTRecoveryEmailPassword { get; set; }
        public string? EWAYBillUserName { get; set; }
        public string? EWAYBillPassword { get; set; }
        public string? RackFileNo { get; set; }
        public string? TallyDataFilePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public Guid? ClientRelationMgrId { get; set; }
        public string ClientRelationMgr { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }



    }
    public class ActiveGSTClientsForDD
    {
        public Guid Id { get; set; }
        public string? GSTClientAndGSTIN { get; set; }

    }


    public class GSTClientCreateDTO
    {
        [Required]
        public string ProprietorName { get; set; }
        [Required]
        public string GSTIN { get; set; }
        public bool isRegular { get; set; }
        public string? ContactName { get; set; }
        public string? GSTUserName { get; set; }
        public string? GSTUserPassword { get; set; }
        [Required]
        public DateTime GSTRegDate { get; set; }
        public DateTime? GSTSurrenderedDate { get; set; }
        public DateTime? GSTRelievedDate { get; set; }
        public double? GSTAnnualTurnOver { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactEmailId { get; set; }
        [Required]
        public string? GSTEmailId { get; set; }
        public string? GSTEmailPassword { get; set; }
        public string? GSTRecoveryEmailId { get; set; }
        public string? GSTRecoveryEmailPassword { get; set; }
        public string? EWAYBillUserName { get; set; }
        public string? EWAYBillPassword { get; set; }
        [Required]
        public string? RackFileNo { get; set; }
        [Required]
        public string? TallyDataFilePath { get; set; }
        [Required]
        public Guid? ClientRelationMgrId { get; set; }
        [Required]
        public int StatusId { get; set; }



    }




    public class GSTClientUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? ProprietorName { get; set; }
        public string? GSTIN { get; set; }
        public bool isRegular { get; set; }
        public string? ContactName { get; set; }
        public string? GSTUserName { get; set; }
        public string? GSTUserPassword { get; set; }
        [Required]
        public DateTime GSTRegDate { get; set; }
        public DateTime? GSTSurrenderedDate { get; set; }
        public DateTime? GSTRelievedDate { get; set; }
        public double? GSTAnnualTurnOver { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactEmailId { get; set; }
        [Required]
        public string? GSTEmailId { get; set; }
        public string? GSTEmailPassword { get; set; }
        public string? GSTRecoveryEmailId { get; set; }
        public string? GSTRecoveryEmailPassword { get; set; }
        public string? EWAYBillUserName { get; set; }
        public string? EWAYBillPassword { get; set; }
        [Required]
        public string? RackFileNo { get; set; }
        [Required]
        public string? TallyDataFilePath { get; set; }

        [Required]
        public Guid? ClientRelationMgrId { get; set; }

        [Required]
        public int StatusId { get; set; }


    }



}
