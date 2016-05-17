using System.Collections.Generic;
using System.Net.Mail;

namespace jcFUS.WebAPI.Helpers {
    public static class EmailHelper {
        public static void SendEmail(string receiver, string subject, string body)
            => SendEmail(new List<string> { receiver }, subject, body);

        public static void SendEmail(List<string> receivers, string subject, string body) {
            using (var smtpClient = new SmtpClient()) {
                var mm = new MailMessage();

                mm.To.Add(string.Join(",", receivers));

                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;

                smtpClient.SendAsync(mm, null);
            }
        }
    }
}