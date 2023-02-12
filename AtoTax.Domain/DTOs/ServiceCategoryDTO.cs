using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtoTax.Domain.DTOs
{
    public class ServiceCategoryDTO
    {

        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public double DefaultCharge { get; set; }
        public double? PreviousCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }

    public class ServiceCategoryCreateDTO
    {
        [Required]
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public double DefaultCharge { get; set; }
        //public double? PreviousCharge { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
        [Required]
        public int? StatusId { get; set; }

    }


    public class ActiveServiceCategoriesForDD
    {
        public int Id { get; set; }
        public string? ServiceNameAndDesc { get; set; }
    }

    public class ServiceCategoryUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public double DefaultCharge { get; set; }

        //public double? PreviousCharge { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
        [Required]
        public int? StatusId { get; set; }

    }
}
