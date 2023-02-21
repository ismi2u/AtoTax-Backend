
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class MonthYearDTO
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }
    }

    public class MonthYearCreateDTO
    {
        [Required]
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required]
        public int StatusId { get; set; }
    }

  

    public class ActiveMonthYearForDD
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }

   
}
