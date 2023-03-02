
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class UserRoleDTO
    {
        public string UserId { get; set; }
        public List<RoleDTO>? ListRoles { get; set; }
    }

   
}
