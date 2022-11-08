using SystemDuo.Core.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface ILinkAttributeRepository : IRepositoryBase<LinkAttribute>
    {
        Task<IEnumerable<LinkAttribute>> GetAllLinkAttributesAsync();
    }
}
