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

       public Guid Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int StatusId { get; set; }

    }
}
