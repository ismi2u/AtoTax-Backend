
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class MonthAndYearDTO
    {
        public int Id { get; set; }
        public string MonthIdx { get; set; }
        public string Month { get; set; }

        public int Year { get; set; }

        public string MonthYear { get; set; }

        public string FiscalYear { get; set; }
    }

  

    public class MonthAndYearForDD
    {
        public int Id { get; set; }
        public string MonthYear { get; set; }
    }

    public class MonthAndYearCreateDTO
    {
        public string MonthIdx { get; set; }
        public string Month { get; set; }

        public int Year { get; set; }

        public string MonthYear { get; set; }

        public string FiscalYear { get; set; }
    }
}
