using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class UpdateUserDTO
    {
        public string Id{ get; set; }

        public string NewUserName { get; set; }
        public string NewName { get; set; }
        public string NewEmail { get; set; }

    }
}