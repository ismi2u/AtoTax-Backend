using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs
{
    public class ApprovalStatusTypeDTO
    {
        public int Id { get; set; }
        public string? StatusType { get; set; }

    }

    

    public enum EApprovalStatusTypes
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3

    }

}
