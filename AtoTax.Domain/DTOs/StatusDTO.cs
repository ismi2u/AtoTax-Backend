namespace AtoTax.Domain.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public string? StatusType { get; set; }

    }


    public class StatusCreateDTO
    {
        public string? StatusType { get; set; }

    }
}
