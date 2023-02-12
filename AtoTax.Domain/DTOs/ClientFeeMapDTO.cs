using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{

    public class ClientFeeMapDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }

        public double DefaultCharge { get; set; }
        public int? ServiceCategoryId { get; set; }
        public ServiceCategoryDTO ServiceCategory { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
    public class ClientFeeMapCreateDTO
    {
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public int ServiceCategoryId { get; set; }
        [Required]
        public double DefaultCharge { get; set; }

    }


    public class ClientFeeMapUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public int ServiceCategoryId { get; set; }

        [Required]
        public double DefaultCharge { get; set; }
    }


}
