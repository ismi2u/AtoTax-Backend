namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class AssignRolesDTO
    {
        public string UserId { get; set; }

        public List<string> RoleIds { get; set; } = new List<string>();
    }
}