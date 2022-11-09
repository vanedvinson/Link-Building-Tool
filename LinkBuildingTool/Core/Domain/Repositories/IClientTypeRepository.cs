using LinkBuildingTool.Core.Domain.Entities;

namespace LinkBuildingTool.Core.Domain.Repositories
{
    public interface IClientTypeRepository : IRepositoryBase<ClientType>
    {
        Task<IEnumerable<ClientType>> GetAllClientTypesAsync();
        Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId);
    }
}
