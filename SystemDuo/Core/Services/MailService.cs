using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using SystemDuo.Core.Dto;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class MailService:IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(Mail mail)
        {
            var smtpClient = new SmtpClient(_mailSettings.SmtpHost)
            {
                Port = _mailSettings.SmtpPort,
                Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_mailSettings.Mail),
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = mail.IsBodyHtml,

            };
            mailMessage.To.Add(mail.ToEmail);

            await smtpClient.SendMailAsync(mailMessage);

        }
    }
}
