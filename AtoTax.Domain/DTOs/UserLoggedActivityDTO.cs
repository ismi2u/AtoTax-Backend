
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class UserLoggedActivityDTO
    {
        public Guid Id { get; set; }

        public int EmployeeId { get; set; }
        public string Activity { get; set; }

        public string AdditionalDetails { get; set; }
        public DateTime loggedDate { get; set; }
    }

    public class UserLoggedActivityCreateDTO
    {
        public int EmployeeId { get; set; }
        public string Activity { get; set; }

        public string AdditionalDetails { get; set; }

    }

    public class UserLoggedActivityUpdateDTO
    {
        public Guid Id { get; set; }

        public int EmployeeId { get; set; }
        public string Activity { get; set; }

        public string AdditionalDetails { get; set; }
        public DateTime loggedDate { get; set; }
    }
}
