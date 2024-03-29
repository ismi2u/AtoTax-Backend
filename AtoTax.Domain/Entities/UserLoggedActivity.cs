﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtoTax.Domain.Entities
{
    public class UserLoggedActivity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string User { get; set; }
        public string Activity { get; set; }

        public string AdditionalDetails { get; set; }

        public DateTime loggedDate { get; set; }

}
}
