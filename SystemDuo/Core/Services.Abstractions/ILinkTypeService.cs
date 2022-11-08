using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface ILinkTypeService
    {
        Task<IEnumerable<LinkType>> GetAllLinkTypesAsync();
    }
}
