using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string UserId{ get; set; }

        public string NewUserName { get; set; }

        public string Password { get; set; }

        public string OldName { get; set; }
        public string NewName { get; set; }
        public string NewEmail { get; set; }
        public string OldEmail { get; set; }

    }
}