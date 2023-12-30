using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
namespace UsersAPI.Services
{


    public class EmailSender
    {
        public static void SendEmail(string toAddress, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sol's Users API", "noreply@sol.com"));
            message.To.Add(new MailboxAddress("", toAddress));
            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("acaciawoodglobal@gmail.com", "xjgbselgsfgudmfi");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }

}
