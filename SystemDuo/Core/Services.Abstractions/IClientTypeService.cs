using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientType>> GetAllClientTypesAsync();
        Task<ClientType> GetClientTypeByIdAsync(Guid clientTypeId);
    }
}
