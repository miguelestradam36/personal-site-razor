using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace miguelestradam.Data
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }

    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? "magnolia.koss@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("magnolia.koss@ethereal.email", "WASAAsMKdnBveqpw4n");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
