using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Services.Abstractions
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientType>> GetAllClientTypesAsync();
        Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId);
    }
}
