using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class MonthAndYear
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string MonthIdx { get; set; }
        public string Month { get; set; }

        public int Year { get; set; }

        public string MonthYear { get; set; }

        public string FiscalYear { get; set; }
    }

   
}
