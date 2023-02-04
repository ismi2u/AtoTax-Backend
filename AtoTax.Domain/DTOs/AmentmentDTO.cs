using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{

    public class AmendmentDTO
    {
        public int Id { get; set; }
        public int GSTClientId { get; set; }
        public int AmendTypeId { get; set; }
        public string ARN { get; set; }
        public DateTime SumittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }



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
     



    }




    public class AmendmentUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GSTClientId { get; set; }
        [Required]
        public int AmendTypeId { get; set; }
        public string ARN { get; set; }
        [Required]
        public DateTime SumittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }

    }



}
