using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using YouStreet.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace YouStreet.Data.EmailSevice
{
    public class EmailService : ISender
    {
        public IConfiguration AppConfiguration { get; set; }
        public EmailService(IConfiguration config)
        {
            AppConfiguration = config;
        }

        public async Task SendMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("YouStreet", AppConfiguration["gmail"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync(AppConfiguration["AdminGmail:Gmail"], AppConfiguration["password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
