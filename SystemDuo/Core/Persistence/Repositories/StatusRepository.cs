﻿using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Data;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {

        }

        public async Task<IEnumerable<Status>> GetAllStatusesTypesAsync()
        {
            var statuses = await FindByCondition(c => c.Id != Guid.Empty).ToListAsync();
            return statuses;
        }

        public async Task<Status> GetStatusByIdAsync(Guid statusId)
        {
            var status = await FindByCondition(c => c.Id.Equals(statusId)).FirstOrDefaultAsync();
            return status!;
        }
    }
}
