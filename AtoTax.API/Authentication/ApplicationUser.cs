using AtoTax.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtoTax.API.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        
    }
}
