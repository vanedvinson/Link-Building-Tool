using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IClientTypeRepository : IRepositoryBase<ClientType>
    {
        Task<IEnumerable<ClientType>> GetAllClientTypesAsync();
        Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId);
    }
}
