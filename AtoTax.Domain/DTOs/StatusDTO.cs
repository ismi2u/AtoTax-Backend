using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public string? StatusType { get; set; }

    }

    

    public class StatusCreateDTO
    {
        [Required]
        public string? StatusType { get; set; }

    }

    public enum EStatus
    {
        active = 1,
        inactive

    }
   

}
