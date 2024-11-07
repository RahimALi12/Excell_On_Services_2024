using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace Excell_On_Services.Models
{
    public class Emailsender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("your email"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = htmlMessage
            //};

            ////nawn mcto lnux hzsj
            //// to generate app password https://myaccount.google.com/apppasswords

            //using (var emailClient = new SmtpClient())
            //{

            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("your email", "your app password");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);

            //}
            return Task.CompletedTask;
        }
    }
}
