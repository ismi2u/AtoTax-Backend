using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{

    public class AmendmentDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public int AmendTypeId { get; set; }
        public AmendTypeDTO AmendType { get; set; }
        public string ARN { get; set; }
        public DateTime SumittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }


    }
    public class AmendmentCreateDTO
    {
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public int AmendTypeId { get; set; }
        public string ARN { get; set; }
        [Required]
        public DateTime SumittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [Required]
        public int StatusId { get; set; }
     


    }




    public class AmendmentUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int GSTClientId { get; set; }
        [Required]
        public int AmendTypeId { get; set; }
        public string ARN { get; set; }
        [Required]
        public DateTime SumittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [Required]
        public int StatusId { get; set; }

    }



}
