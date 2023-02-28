using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSMTPConfiguration
    {

        public string From { get; set; } = "life.test@rediffmail.com";
        public string DisplayName { get; set; } = "sendgridEmail";
        public string SmtpServer { get; set; } = "smtp.sendgrid.net";
        public int Port { get; set; } = 587;
        public bool StartTLS { get; set; } = true;
        public string UserName { get; set; } = "apikey";
        public string Password { get; set; } = "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";
   
    }
}
