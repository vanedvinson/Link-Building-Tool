using SystemDuo.Core.Dto;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail mail);
    }
}
