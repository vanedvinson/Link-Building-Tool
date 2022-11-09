using LinkBuildingTool.Core.Dto;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface IMailService
    {
        Task SendEmailAsync(Mail mail);
    }
}
