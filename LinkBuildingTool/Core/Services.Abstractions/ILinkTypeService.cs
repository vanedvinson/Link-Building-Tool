using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface ILinkTypeService
    {
        Task<IEnumerable<LinkType>> GetAllLinkTypesAsync();
    }
}
