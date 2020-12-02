using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using YouStreet.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace YouStreet.Data.EmailSevice
{
    public class EmailService : ISender
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("YouStreet", _configuration["gmail"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true); 
                await client.AuthenticateAsync(_configuration["gmail"], _configuration["password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
