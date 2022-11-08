using SystemDuo.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface ILinkAttributeService
    {
        Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync();
    }
}
