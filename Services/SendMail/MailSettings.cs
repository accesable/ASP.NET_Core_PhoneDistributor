using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace WebApplication_Slicone_Supplier.Services.SendMail
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }

}
