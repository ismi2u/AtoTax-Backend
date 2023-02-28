namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class UpdateUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string OldName { get; set; }
        public string NewName { get; set; }
        public string NewEmail { get; set; }
        public string OldEmail { get; set; }

    }
}