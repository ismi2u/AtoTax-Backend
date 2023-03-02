
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class RoleDTO
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

}
