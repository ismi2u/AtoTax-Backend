using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSMTPConfiguration
    {

        public string From { get; set; } = "carli.oreilly@ethereal.email";
        public string DisplayName { get; set; } = "ethereal";
        public string SmtpServer { get; set; } = "smtp.ethereal.email";
        public int Port { get; set; } = 587;
        public bool StartTLS { get; set; } = true;
        public string UserName { get; set; } = "carli.oreilly@ethereal.email";
        public string Password { get; set; } = "sDAjaSMcezsBYcqC5R";
   
    }
}
